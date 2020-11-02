using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository itempedidoRepository;

        public ItemPedidoService(IItemPedidoRepository itempedidoRepository)
        {
            this.itempedidoRepository = itempedidoRepository;
        }

        public ItemPedido UpdateQuantidade(ItemPedido itemPedido)
        {
            return itempedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
