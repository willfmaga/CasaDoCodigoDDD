using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CasaDoCodigo.Infra.Data
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext applicationContext, IProdutoRepository produtoRepository)
        {
            _applicationContext = applicationContext;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            _applicationContext.Database.Migrate();

            List<Livro> livros = GetLivros();

            _produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
