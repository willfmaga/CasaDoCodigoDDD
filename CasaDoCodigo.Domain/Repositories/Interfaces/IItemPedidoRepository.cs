﻿using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        ItemPedido Adicionar(ItemPedido itemPedido);
        ItemPedido GetByCodigo(string codigoProduto, int pedidoId);

        ItemPedido UpdateQuantidade(ItemPedido itemPedido);

        void RemoveItemPedido(int itemPedidoId);
    }
}
