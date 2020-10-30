using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services.Interfaces
{
    public interface IItemPedidoService
    {
        void UpdateQuantidade(ItemPedido itemPedido);
    }
}
