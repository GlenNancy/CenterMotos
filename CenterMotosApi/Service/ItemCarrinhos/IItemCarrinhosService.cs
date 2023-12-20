using CenterMotosApi.Models;

namespace CenterMotosApi.Services
{
    public interface IItemCarrinhosService
    {
        public Task<ItemCarrinho> GetItemCarrinhoByIdAsync(int id);
        public Task<IEnumerable<ItemCarrinho>> GetAllItemCarrinhoAsync();
        public Task<ItemCarrinho> CreateItemCarrinhoAsync(ItemCarrinho itemCarrinho);
        public Task<ItemCarrinho> RemoveItemCarrinho(int id);
    }
}