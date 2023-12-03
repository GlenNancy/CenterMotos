using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        public Task<IEnumerable<Cliente>> GetAllClienteAsync();
        public Task<Cliente> GetClienteByIdAsync(int id);
        public Task CreateClienteAsync(Cliente cliente);
        public Task RemoveCliente(Cliente cliente);
        public Task<Cliente> GetClienteByCPFAsync(string cpf);
    }
}