using CasaDoCodigo.Application.Interfaces;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Application.Services
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly IProdutoService produtoService;

        public ProdutoApp(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        public IList<Produto> GetProdutos()
        {
            return produtoService.GetProdutos();
        }
    }
}
