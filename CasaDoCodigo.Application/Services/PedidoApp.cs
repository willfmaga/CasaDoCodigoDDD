using CasaDoCodigo.Application.Interfaces;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Application.Services
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoService pedidoService;

        public PedidoApp(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        public void AddItem(string codigo, Pedido pedido)
        {
            pedidoService.AddItem(codigo, pedido);
        }

        public Pedido GetPedido(int? pedidoId)
        {
            return pedidoService.GetPedido(pedidoId);
        }
    }
}
