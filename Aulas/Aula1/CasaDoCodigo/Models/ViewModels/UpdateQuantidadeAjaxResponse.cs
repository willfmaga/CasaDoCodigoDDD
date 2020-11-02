using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Models.ViewModels
{
    public class UpdateQuantidadeAjaxResponse
    {
        public UpdateQuantidadeAjaxResponse(ItemPedido itemPedido, CarrinhoViewModel carinho)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carinho;
        }

        public ItemPedido ItemPedido { get; }

        public CarrinhoViewModel CarrinhoViewModel { get; }
    }
}
