using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly DataContext _context;

        public ComentariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Comentario comentario = await _context.Comentarios.FirstOrDefaultAsync(c => c.Id == id);

                if (comentario == null)
                {
                    return NotFound("Comentário não encontrado");
                }

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<Comentario> lista = await _context.Comentarios.ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhum comentário encontrado.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost("RegistrarComentario")]
        public async Task<IActionResult> RegistrarComentarioAsync([FromBody] Comentario comentario)
        {
            try
            {
                if (comentario == null)
                {
                    return BadRequest("O comentário não pode ser nulo.");
                }

                if (string.IsNullOrEmpty(comentario.DescricaoComentario) || comentario.DescricaoComentario.Length <= 2)
                {
                    return BadRequest("O comentário deve ter no mínimo 3 caracteres.");
                }

                Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == comentario.ClienteId);

                comentario.Nome = cliente.Nome;

                await _context.Comentarios.AddAsync(comentario);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Comentário registrado com sucesso", Comentario = comentario });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizarComentario/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comentario comentarioAtualizado)
        {
            try
            {
                Comentario comentarioExistente = await _context.Comentarios.FirstOrDefaultAsync(c => c.Id == id);

                if (comentarioExistente == null)
                {
                    return NotFound("Comentario não encontrado");
                }

                if (comentarioAtualizado == null)
                {
                    return BadRequest("O comentario atualizado é nulo.");
                }

                Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == comentarioAtualizado.ClienteId);
                comentarioAtualizado.Nome = cliente.Nome;

                comentarioExistente.DescricaoComentario = comentarioAtualizado.DescricaoComentario;

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Comentario atualizado com sucesso", Comentario = comentarioExistente });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Comentario comentario = await _context.Comentarios.FirstOrDefaultAsync(delete => delete.Id == id);

                if (comentario == null)
                {
                    return NotFound("Comentario não encontrado");
                }

                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Comentario excluído com sucesso", Comentario = comentario });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}