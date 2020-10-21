using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Infra.Data.Repositories
{
    public class ProdutoRepository :BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (Livro livro in livros)
            {
                if (!dbSet.Where(c => c.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(
                         new Produto(livro.Codigo, livro.Nome, livro.Preco)
                      );
                }
                contexto.SaveChanges();
            }
        }
    }
}