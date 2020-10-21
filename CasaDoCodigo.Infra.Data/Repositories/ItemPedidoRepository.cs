using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Infra.Data.Repositories
{
    public class ItemPedidoRepository : BaseRepository<Pedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
