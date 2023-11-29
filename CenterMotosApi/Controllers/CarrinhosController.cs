using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarrinhosController : ControllerBase
    {
        private readonly DataContext _context;

        public CarrinhosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Carrinho carrinho = await _context.Carrinhos
                    .Include(c => c.Cliente)
                    .ThenInclude(cliente => cliente.Comentarios)
                    .Include(c => c.ItensCarrinho)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (carrinho == null)
                {
                    return NotFound("Carrinho não encontrado");
                }

                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost("CriarCarrinho")]
        public async Task<IActionResult> CriarCarrinho([FromBody] Carrinho carrinho)
        {
            try
            {
                if (carrinho == null)
                {
                    return BadRequest("O carrinho não pode ser nulo.");
                }

                // Verificar se o cliente já possui um carrinho
                Carrinho carrinhoExistente = await _context.Carrinhos.FirstOrDefaultAsync(c => c.ClienteId == carrinho.ClienteId);

                if (carrinhoExistente != null)
                {
                    return BadRequest("O cliente já possui um carrinho ativo.");
                }

                _context.Carrinhos.Add(carrinho);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCarrinhoById", new { id = carrinho.Id }, carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCarrinho(int id)
        {
            try
            {
                Carrinho carrinho = await _context.Carrinhos.FindAsync(id);

                if (carrinho == null)
                {
                    return NotFound("Carrinho não encontrado");
                }

                // Remover a referência ao carrinho do cliente
                var clienteComCarrinho = await _context.Clientes.Where(c => c.CarrinhoId == id).ToListAsync();
                foreach (var cliente in clienteComCarrinho)
                {
                    cliente.CarrinhoId = null;
                }

                _context.Carrinhos.Remove(carrinho);
                await _context.SaveChangesAsync();

                return Ok("Carrinho excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}