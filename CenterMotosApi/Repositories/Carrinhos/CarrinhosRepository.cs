using CenterMotosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories
{
    public class CarrinhosRepository : ICarrinhosRepository
    {
        private readonly DataContext _context;
        public CarrinhosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> GetCarrinhoByIdAsync(int id)
        {
            return await _context.Carrinhos
                    .Include(c => c.Cliente)
                    .Include(c => c.ItensCarrinho)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Carrinho>> GetAllCarrinhoAsync()
        {
            List<Carrinho> carrinhos = await _context.Carrinhos
                .Include(c => c.Cliente)
                .Include(c => c.ItensCarrinho)
                .ThenInclude(c => c.Produto)
                .ToListAsync();

            return carrinhos;
        }

        public async Task CreateCarrinhoAsync(Carrinho carrinho)
        {
            await _context.Carrinhos.AddAsync(carrinho);
        }

        public async Task RemoveCarrinho(Carrinho carrinho)
        {
            _context.Carrinhos.Remove(carrinho);
        }
    }
}