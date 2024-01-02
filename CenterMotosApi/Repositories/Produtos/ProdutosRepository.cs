using CenterMotosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly DataContext _context;
        public ProdutosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos
                    .Include(p => p.Comentarios) // Inclui os comentários associados ao produto
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetAllProdutoAsync()
        {
            IEnumerable<Produto> produtos = await _context.Produtos
                    .Include(p => p.Comentarios)
                    .ToListAsync();

            return produtos;
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
             await _context.Produtos.AddAsync(produto);
        }

        public async Task RemoveProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }
    }
}