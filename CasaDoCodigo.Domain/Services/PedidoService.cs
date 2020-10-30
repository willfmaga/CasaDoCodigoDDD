using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces.Repositories;
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
        private readonly IProdutoRepository produtoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.produtoRepository = produtoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem(string codigo, Pedido pedido)
        {
            var produto = produtoRepository.GetByCodigo(codigo);

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var itemPedido = itemPedidoRepository.GetByCodigo(codigo, pedido.Id);

            if (itemPedido == null)
            {
                itemPedidoRepository.Adicionar(new ItemPedido(pedido, produto,1,produto.Preco));
            }

        }

        public Pedido GetPedido(int? pedidoId)
        {
            return pedidoRepository.GetPedido(pedidoId);
        }
    }
}
