using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface IProdutosRepository
    {
        public Task<Produto> GetProdutoByIdAsync(int id);
        public Task<IEnumerable<Produto>> GetAllProdutoAsync();
        public Task CreateProdutoAsync(Produto produto);
        public Task RemoveProduto(Produto produto);
    }
}