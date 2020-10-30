using CasaDoCodigo.Domain.Entities;
using System.Collections.Generic;

namespace CasaDoCodigo.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);

        IList<Produto> GetProdutos();

        Produto GetByCodigo(string codigoProduto);
    }
}