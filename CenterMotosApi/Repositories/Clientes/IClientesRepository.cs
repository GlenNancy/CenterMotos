using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        public Task<Cliente> GetClienteByIdAsync(int id);
        public Task<IEnumerable<Cliente>> GetAllClienteAsync();
        public Task CreateClienteAsync(Cliente cliente);
        public Task RemoveCliente(Cliente cliente);
        public Task<Cliente> GetClienteByCPFAsync(string cpf);
    }
}