using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace CenterMotosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinhos { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
