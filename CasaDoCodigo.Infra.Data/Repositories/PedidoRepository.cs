using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Infra.Data.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Pedido GetPedido(int? pedidoId)
        {
            Pedido pedido = null;

            if (pedidoId.HasValue)
                pedido = dbSet.Where(p => p.Id == pedidoId)
                    .Include(p =>p.Itens)
                        .ThenInclude (i => i.Produto) 
                            .SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                
                dbSet.Add(pedido);
                contexto.SaveChanges();
            }

            return pedido;
        }
    }
}
