using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces.Repositories;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IList<Produto> GetProdutos()
        {
            return produtoRepository.GetProdutos();
        }
    }
}
