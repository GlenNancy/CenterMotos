using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface IItemCarrinhosRepository
    {
        public Task<ItemCarrinho> GetItemCarrinhoByIdAsync(int id);
        public Task<IEnumerable<ItemCarrinho>> GetAllItemCarrinhoAsync();
        public Task CreateItemCarrinhoAsync(ItemCarrinho itemCarrinho);
        public Task RemoveItemCarrinho(ItemCarrinho itemCarrinho);
    }
}
