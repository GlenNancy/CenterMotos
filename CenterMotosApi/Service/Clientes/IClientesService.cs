using CenterMotosApi.Models;

namespace CenterMotosApi.Services
{
    public interface IClientesService
    {
        public Task<IEnumerable<Cliente>> GetAllClienteAsync();
        public Task<Cliente> GetClienteByIdAsync(int id);
        public Task<Cliente> CreateClienteAsync(Cliente cliente);
        public Task<Cliente> UpdateClienteAsync(int id, Cliente cliente);
        public Task<Cliente> RemoveCliente(int id);
    }
}