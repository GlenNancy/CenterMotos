using CenterMotosApi.Models;

namespace CenterMotosApi.Services
{
    public interface IComentariosService
    {
        public Task<Comentario> GetComentarioByIdAsync(int id);
        public Task<IEnumerable<Comentario>> GetAllComentarioAsync();
        public Task<Comentario> CreateComentarioAsync(Comentario comentario);
        public Task<Comentario> UpdateComentarioAsync(int id, Comentario comentario);
        public Task<Comentario> RemoveComentario(int id);
    }
}