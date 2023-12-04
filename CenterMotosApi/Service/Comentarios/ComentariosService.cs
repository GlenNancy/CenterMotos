using CenterMotosApi.Models;
using CenterMotosApi.Repositories.Interfaces;
using CenterMotosApi.Repositories.UnitOfWork;
using CenterMotosApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using CenterMotosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Services
{
    public class ComentariosService : IComentariosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        private readonly IComentariosRepository _comentariosRepository;
        private readonly IClientesRepository _clientesRepository;

        public ComentariosService(DataContext context, IComentariosRepository comentariosRepository, IUnitOfWork unitOfWork, IClientesRepository clientesRepository)
        {
            _context = context;
            _comentariosRepository = comentariosRepository;
            _clientesRepository = clientesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Comentario> GetComentarioByIdAsync(int id)
        {
            Comentario comentario = await _comentariosRepository.GetComentarioByIdAsync(id);

            if (comentario == null)
            {
                throw new NotFoundException("Comentário não encontrado");
            }

            return comentario;
        }

        public async Task<IEnumerable<Comentario>> GetAllComentarioAsync()
        {
            IEnumerable<Comentario> comentarios = await _comentariosRepository.GetAllComentarioAsync();

            if (!comentarios.Any())
            {
                throw new NotFoundException("Nenhum comentario encontrado.");
            }

            return comentarios;
        }

        public async Task<Comentario> CreateComentarioAsync(Comentario comentario)
        {
            if (comentario == null)
            {
                throw new NotFoundException("O comentário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(comentario.DescricaoComentario) || comentario.DescricaoComentario.Length <= 2)
            {
                throw new NotFoundException("O comentário deve ter no mínimo 3 caracteres.");
            }

            Cliente cliente = await _clientesRepository.GetClienteByIdAsync(comentario.ClienteId);

            comentario.Nome = cliente.Nome;

            //arrumar futuramente
            Produto produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == comentario.ProdutoId);

            comentario.Nome_Produto = produto.Nome;

            await _comentariosRepository.CreateComentarioAsync(comentario);
            await _unitOfWork.SaveChangesAsync();

            return comentario;
        }

        public async Task<Comentario> UpdateComentarioAsync(int id, Comentario comentario)
        {
            Comentario comentarioExistente = await _comentariosRepository.GetComentarioByIdAsync(id);

            if (comentarioExistente == null)
            {
                throw new NotFoundException("Comentario não encontrado");
            }

            if (comentario == null)
            {
                throw new NotFoundException("O comentario atualizado é nulo.");
            }

            Cliente cliente = await _clientesRepository.GetClienteByIdAsync(comentario.ClienteId);
            comentario.Nome = cliente.Nome;

            comentarioExistente.DescricaoComentario = comentario.DescricaoComentario;

            await _unitOfWork.SaveChangesAsync();

            return comentario;
        }

        public async Task<Comentario> RemoveComentario(int id)
        {
            Comentario comentarioExistente = await _comentariosRepository.GetComentarioByIdAsync(id);

            if (comentarioExistente == null)
            {
                throw new NotFoundException("Comentario não encontrado");
            }

            await _comentariosRepository.RemoveComentario(comentarioExistente);
            await _unitOfWork.SaveChangesAsync();

            return comentarioExistente;
        }
    }
}