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

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            _itemPedidoService.UpdateQuantidade(itemPedido);
        }
    }
}
