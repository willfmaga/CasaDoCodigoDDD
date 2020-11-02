using CasaDoCodigo.Application.Interfaces;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Application.Services
{
    public class ItemPedidoApp : IItemPedidoApp
    {
        private readonly IItemPedidoService _itemPedidoService;

        public ItemPedidoApp(IItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        public ItemPedido UpdateQuantidade(ItemPedido itemPedido)
        {
           return _itemPedidoService.UpdateQuantidade(itemPedido);
        }
    }
}
