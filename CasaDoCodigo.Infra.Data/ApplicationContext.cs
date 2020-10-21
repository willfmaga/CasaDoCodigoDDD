using CasaDoCodigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            modelBuilder.Entity<ItemPedido>().HasKey(ip => ip.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Produto);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Pedido);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(c => c.Pedido).IsRequired();
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(p => p.Pedido);

            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>().HasOne(p => p.Pedido).WithOne(c => c.Cadastro);
        }
    }
}
