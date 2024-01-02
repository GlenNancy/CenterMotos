using CenterMotosApi.Models;

namespace CenterMotosApi.Services
{
    public interface IProdutosService
    {
        public Task<Produto> GetProdutoByIdAsync(int id);
        public Task<IEnumerable<Produto>> GetAllProdutoAsync();
        public Task<Produto> CreateProdutoAsync(Produto produto);
        public Task<Produto> UpdateProdutoAsync(int id, Produto produto);
        public Task<Produto> RemoveProduto(int id);
    }
}