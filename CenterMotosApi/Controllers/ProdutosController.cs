using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;
using CenterMotosApi.Services;


namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProdutosService _produtosService;

        public ProdutosController(DataContext context, IProdutosService produtosService)
        {
            _context = context;
            _produtosService = produtosService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Produto produto = await _produtosService.GetProdutoByIdAsync(id);

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
                IEnumerable<Produto> produto = await _produtosService.GetAllProdutoAsync();

                return Ok(produto);
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
                await _produtosService.CreateProdutoAsync(produto);

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
                Produto produtoExistente = await _produtosService.UpdateProdutoAsync(id, produtoAtualizado);

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
                Produto produto = await _produtosService.GetProdutoByIdAsync(id);
                await _produtosService.RemoveProduto(id);

                return Ok(new { Message = "Produto excluído com sucesso", Produto = produto });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}