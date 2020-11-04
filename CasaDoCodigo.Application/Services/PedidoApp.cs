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
        private readonly ICadastroService cadastroService;

        public PedidoApp(IPedidoService pedidoService, IItemPedidoService itemPedidoService, ICadastroService cadastroService)
        {
            this.pedidoService = pedidoService;
            this.itemPedidoService = itemPedidoService;
            this.cadastroService = cadastroService;
        }

        public void AddItem(string codigo, Pedido pedido)
        {
            pedidoService.AddItem(codigo, pedido);
        }

        public Pedido GetPedido(int? pedidoId)
        {
            return pedidoService.GetPedido(pedidoId);
        }

        public Pedido UpdateCadastro(Pedido pedido,Cadastro cadastro)
        {
            cadastroService.Update(pedido.Id, cadastro);

            return pedido;
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
