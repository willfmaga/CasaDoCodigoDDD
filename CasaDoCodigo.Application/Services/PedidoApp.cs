using CasaDoCodigo.Application.Interfaces;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Services.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Application.Services
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoService pedidoService;
        private readonly IItemPedidoService itemPedidoService;

        public PedidoApp(IPedidoService pedidoService, IItemPedidoService itemPedidoService)
        {
            this.pedidoService = pedidoService;
            this.itemPedidoService = itemPedidoService;
        }

        public void AddItem(string codigo, Pedido pedido)
        {
            pedidoService.AddItem(codigo, pedido);
        }

        public Pedido GetPedido(int? pedidoId)
        {
            return pedidoService.GetPedido(pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido, Int32 pedidoId)
        {
            var itempedidoDB = itemPedidoService.UpdateQuantidade(itemPedido);

            if (itempedidoDB.Quantidade == 0)
            {
                itemPedidoService.RemoveItemPedido(itempedidoDB.Id);
            }

            var pedido = pedidoService.GetPedido(pedidoId);

            return new UpdateQuantidadeResponse(itempedidoDB, pedido);

        }
    }
}
