using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;


namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Produto produto = await _context.Produtos
                    .Include(p => p.Comentarios)            // Inclui os comentários associados ao produto
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (produto == null)
                {
                    return NotFound("Produto não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Produto> lista = await _context.Produtos
                    .Include(p => p.Comentarios)
                    .ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhum produto encontrado.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }


        [HttpPost("RegistrarProduto")]
        public async Task<IActionResult> RegistrarProdutoAsync([FromBody] Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return BadRequest("O objeto de produto enviado é nulo.");
                }

                if (string.IsNullOrEmpty(produto.Nome) || produto.Nome.Length > 40)
                {
                    return BadRequest("O campo Nome deve ter entre 1 e 40 caracteres.");
                }

                if (string.IsNullOrEmpty(produto.Descricao) || produto.Descricao.Length > 255)
                {
                    return BadRequest("O campo Descrição deve ter entre 1 e 255 caracteres.");
                }

                if (produto.Preco <= 0)
                {
                    return BadRequest("O campo Preço deve ser maior que zero.");
                }

                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Produto registrado com sucesso", Produto = produto });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizarProduto/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Produto produtoAtualizado)
        {
            try
            {
                Produto produtoExistente = await _context.Produtos.FindAsync(id);

                if (produtoExistente == null)
                {
                    return NotFound("Produto não encontrado");
                }

                if (produtoAtualizado == null)
                {
                    return BadRequest("O objeto de produto atualizado é nulo.");
                }


                produtoExistente.Nome = produtoAtualizado.Nome;
                produtoExistente.Descricao = produtoAtualizado.Descricao;
                produtoExistente.Foto = produtoAtualizado.Foto;
                produtoExistente.Preco = produtoAtualizado.Preco;

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Produto atualizado com sucesso", Produto = produtoExistente });
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
                Produto produto = await _context.Produtos.FirstOrDefaultAsync(delete => delete.Id == id);

                if (produto == null)
                {
                    return NotFound("Produto não encontrado");
                }

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Produto excluído com sucesso", Produto = produto });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}