using CenterMotosApi.Models;

namespace CenterMotosApi.Services
{
    public interface ICarrinhoService
    {
        public Task<Carrinho> GetCarrinhoByIdAsync(int id);
        public Task<IEnumerable<Carrinho>> GetAllCarrinhoAsync();
        public Task<Carrinho> CreateCarrinhoAsync(Carrinho carrinho);
        public Task<Carrinho> RemoveCarrinho(int id);
    }
}