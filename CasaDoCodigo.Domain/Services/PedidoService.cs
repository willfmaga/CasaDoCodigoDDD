using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public Pedido GetPedido(int? pedidoId)
        {
            return pedidoRepository.GetPedido(pedidoId);
        }
    }
}
