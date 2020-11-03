using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Application.Interfaces
{
    public interface IItemPedidoApp
    {
        ItemPedido UpdateQuantidade(ItemPedido itemPedido);
    }
}