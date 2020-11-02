using CasaDoCodigo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModels 
{
    public class CarrinhoViewModel
    {
        public IList<ItemPedido> Itens { get; }

        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }

        public decimal Total => Itens.Sum(x => x.PrecoUnitario * x.Quantidade);


    }
}
