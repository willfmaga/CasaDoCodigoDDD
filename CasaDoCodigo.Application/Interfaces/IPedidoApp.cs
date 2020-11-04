using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CasaDoCodigo.Application.Interfaces
{
    public interface IPedidoApp
    {
        Pedido GetPedido(int? pedidoId);
        void AddItem(string codigo, Pedido pedido);

        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido, Int32 pedidoId);

        Pedido UpdateCadastro(Pedido pedido,Cadastro cadastro);
    }
}
