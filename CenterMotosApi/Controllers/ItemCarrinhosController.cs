using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;
using CenterMotosApi.DTO;
using CenterMotosApi.Services;

namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemCarrinhosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IItemCarrinhosService _itemCarrinhosService;

        public ItemCarrinhosController(DataContext context, IItemCarrinhosService itemCarrinhosService)
        {
            _context = context;
            _itemCarrinhosService = itemCarrinhosService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ItemCarrinho itemCarrinho = await _itemCarrinhosService.GetItemCarrinhoByIdAsync(id);
                ItemCarrinhoDTO itemCarrinhoDTO = itemCarrinho.ToItemCarrinho();

                return Ok(itemCarrinhoDTO);
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
                IEnumerable<ItemCarrinho> itemCarrinho = await _itemCarrinhosService.GetAllItemCarrinhoAsync();
                IEnumerable<ItemCarrinhoDTO> itemCarrinhoDTO = itemCarrinho.Select(i => i.ToItemCarrinho());

                return Ok(itemCarrinhoDTO);
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
                await _itemCarrinhosService.CreateItemCarrinhoAsync(itemCarrinho);

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
            try
            {
                ItemCarrinho itemCarrinho = await _itemCarrinhosService.GetItemCarrinhoByIdAsync(id);
                await _itemCarrinhosService.RemoveItemCarrinho(id);

                return Ok(new { Message = "Item excluído com sucesso", ItemCarrinho = itemCarrinho });

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}