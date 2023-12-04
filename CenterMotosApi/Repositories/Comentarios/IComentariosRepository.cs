using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories.Interfaces
{
    public interface IComentariosRepository
    {
        public Task<Comentario> GetComentarioByIdAsync(int id);
        public Task<IEnumerable<Comentario>> GetAllComentarioAsync();
        public Task CreateComentarioAsync(Comentario comentario);
        public Task RemoveComentario(Comentario comentario);
    }
}