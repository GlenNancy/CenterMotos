using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface ICarrinhosRepository
    {
        public Task<Carrinho> GetCarrinhoByIdAsync(int id);
        public Task<IEnumerable<Carrinho>> GetAllCarrinhoAsync();
        public Task CreateCarrinhoAsync(Carrinho carrinho);
        public Task RemoveCarrinho(Carrinho carrinho);
    }
}