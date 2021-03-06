﻿using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services.Interfaces
{
    public interface IPedidoService
    {
        Pedido GetPedido(int? pedidoId);
        void AddItem(string codigo, Pedido pedido);
    }
}
