using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;

namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemCarrinhosController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemCarrinhosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<ItemCarrinho> lista = await _context.ItemCarrinhos.ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhum Item encontrado.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost("AdicionarItem")]
        public async Task<IActionResult> AdicionarItem([FromBody] ItemCarrinho itemCarrinho)
        {
            try
            {
                Produto produto = await _context.Produtos.FindAsync(itemCarrinho.ProdutoId);

                if (itemCarrinho == null)
                {
                    return BadRequest("O item não pode ser nulo.");
                }

                if (itemCarrinho.Quantidade <= 0)
                {
                    return BadRequest("Deve ser especificado a Quantidade");
                }

                if (produto == null)
                {
                    return BadRequest("Produto não encontrado");
                }

                itemCarrinho.PrecoUnitario = produto.Preco;

                await _context.ItemCarrinhos.AddAsync(itemCarrinho);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Item adicionado com sucesso", ItemCarrinho = itemCarrinho });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ItemCarrinho itemCarrinho = await _context.ItemCarrinhos.FirstOrDefaultAsync(delete => delete.Id == id);

            if(itemCarrinho == null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.ItemCarrinhos.Remove(itemCarrinho);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Item excluído com sucesso", ItemCarrinho = itemCarrinho });
        }
    }
}