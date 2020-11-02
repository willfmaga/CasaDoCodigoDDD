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
        private readonly IItemPedidoApp itemPedidoApp;

        public PedidoApp(IPedidoService pedidoService, IItemPedidoApp itemPedidoApp)
        {
            this.pedidoService = pedidoService;
            this.itemPedidoApp = itemPedidoApp;
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
            var itempedidoDB = itemPedidoApp.UpdateQuantidade(itemPedido);

            var pedido = pedidoService.GetPedido(pedidoId);

            return new UpdateQuantidadeResponse(itempedidoDB, pedido);

        }
    }
}
