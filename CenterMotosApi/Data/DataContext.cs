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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData
            (
                new Cliente() { Id = 1, Nome = "Mauricio", Cpf = "12345678910", Senha = "123456" },
                new Cliente() { Id = 2, Nome = "Antonio", Cpf = "12345678911", Senha = "123456" }
            );

            modelBuilder.Entity<Mecanico>().HasData
            (
                new Mecanico() { Id = 1, Nome = "Thiago", Cpf = "12345678912", Senha = "123456" },
                new Mecanico() { Id = 2, Nome = "Birobiro", Cpf = "12345678913", Senha = "123456" }
            );

            modelBuilder.Entity<Produto>().HasData
            (
                new Produto() { Id = 1, Nome = "Retrovisor", Foto = null, Descricao = "Retrovisor Titan 150 / 160 2014- Esquerdo MOD Original (GVS) Cada - 4001", Preco = 19.00M },
                new Produto() { Id = 2, Nome = "Capacete", Foto = null, Descricao = "Capacete PRO TORK V-PRO JET 3 Articulado", Preco = 208.99M },
                new Produto() { Id = 3, Nome = "Bateria", Foto = null, Descricao = "Bateria Pioneiro YTX7LBS (MBR7-BS) Selada Falcon / Twister / Tornado / Fazer 250 / Lander / TITAN150", Preco = 162.75M }
            );

            modelBuilder.Entity<Comentario>().HasData
            (
                new Comentario() { Id = 1, ProdutoId = 1, ClienteId = 1, Nome = "aleatorio", Nome_Produto = "nada", DescricaoComentario = "Retrovisor excelente, bonito e barato"},
                new Comentario() { Id = 2, ProdutoId = 1, ClienteId = 2, Nome = "aleatorio", Nome_Produto = "nada", DescricaoComentario = "Retrovisor ficou pequeno na minha cb1000, mas fora isso é muito bom"}
            );

            modelBuilder.Entity<Carrinho>().HasData
            (
                new Carrinho() { Id = 1, ClienteId = 1 },
                new Carrinho() { Id = 2, ClienteId = 2 }
            );
        }
    }
}
