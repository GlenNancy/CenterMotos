using CenterMotosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories
{
    public class ItemCarrinhosRepository : IItemCarrinhosRepository
    {
        private readonly DataContext _context;
        public ItemCarrinhosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemCarrinho> GetItemCarrinhoByIdAsync(int id)
        {
            return await _context.ItemCarrinhos
                .Include(item => item.Produto)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<ItemCarrinho>> GetAllItemCarrinhoAsync()
        {
            List<ItemCarrinho> lista = await _context.ItemCarrinhos
                .Include(item => item.Produto)
                .ToListAsync();

            return lista;
        }

        public async Task CreateItemCarrinhoAsync(ItemCarrinho itemCarrinho)
        {
            await _context.ItemCarrinhos.AddAsync(itemCarrinho);
        }

        public async Task RemoveItemCarrinho(ItemCarrinho itemCarrinho)
        {
           _context.ItemCarrinhos.Remove(itemCarrinho);
        }
    }
}