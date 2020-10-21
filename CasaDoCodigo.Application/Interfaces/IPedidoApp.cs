using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Application.Interfaces
{
    public interface IPedidoApp
    {
        Pedido GetPedido(int? pedidoId);
    }
}
