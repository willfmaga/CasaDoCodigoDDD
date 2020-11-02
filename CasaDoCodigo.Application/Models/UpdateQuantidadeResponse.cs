using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemPedido itemPedido, Pedido pedido)
        {
            ItemPedido = itemPedido;
            Pedido = pedido;
        }

        public ItemPedido ItemPedido { get; }

        public Pedido Pedido { get; }
    }
}
