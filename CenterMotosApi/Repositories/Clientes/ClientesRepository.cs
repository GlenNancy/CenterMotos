using CenterMotosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly DataContext _context;
        public ClientesRepository(DataContext context)
        {
            _context = context;
        }
 
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(p => p.Comentarios)
                .Include(p => p.Carrinho)
                .ThenInclude(c => c.ItensCarrinho)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            IEnumerable<Cliente> clientes = await _context.Clientes
                    .Include(c => c.Comentarios)
                    .Include(c => c.Carrinho) 
                    .ThenInclude(c => c.ItensCarrinho)
                    .ToListAsync();
            
            return clientes;
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public async Task RemoveCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public async Task<Cliente> GetClienteByCPFAsync(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }
    }
}
