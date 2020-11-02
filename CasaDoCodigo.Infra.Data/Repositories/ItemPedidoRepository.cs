using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CasaDoCodigo.Infra.Data.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public ItemPedido Adicionar(ItemPedido itemPedido)
        {
            dbSet.Add(itemPedido);
            contexto.SaveChanges();

            return itemPedido;
        }

        public ItemPedido GetByCodigo(string codigoProduto, int pedidoId)
        {
            return dbSet.Where(ip => ip.Produto.Codigo == codigoProduto && ip.Pedido.Id == pedidoId).SingleOrDefault();
        }

        public ItemPedido UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = dbSet.Where(ip => ip.Id == itemPedido.Id).SingleOrDefault();

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                contexto.SaveChanges();
            }

            return itemPedidoDB;

        }
    }
}
