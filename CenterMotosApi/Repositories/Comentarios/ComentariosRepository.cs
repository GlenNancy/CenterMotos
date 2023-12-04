using CenterMotosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly DataContext _context;
        public ComentariosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Comentario> GetComentarioByIdAsync(int id)
        {
            return await _context.Comentarios.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comentario>> GetAllComentarioAsync()
        {
            IEnumerable<Comentario> comentarios = await _context.Comentarios.ToListAsync();

            return comentarios;
        }

        public async Task CreateComentarioAsync(Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
        }

        public async Task RemoveComentario(Comentario comentario)
        {
            _context.Comentarios.Remove(comentario);
        }
    }
}