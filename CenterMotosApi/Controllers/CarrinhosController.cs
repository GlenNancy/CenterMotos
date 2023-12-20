using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;
using CenterMotosApi.Services;
using CenterMotosApi.DTO;

namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarrinhosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICarrinhoService _carrinhosService;

        public CarrinhosController(DataContext context, ICarrinhoService carrinhoService)
        {
            _context = context;
            _carrinhosService = carrinhoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Carrinho carrinho = await _carrinhosService.GetCarrinhoByIdAsync(id);
                CarrinhoDTO carrinhoDTO = carrinho.ToCarrinho();

                return Ok(carrinhoDTO);
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
                IEnumerable<Carrinho> carrinho = await _carrinhosService.GetAllCarrinhoAsync();
                IEnumerable<CarrinhoDTO> carrinhoDTO = carrinho.Select(c => c.ToCarrinho());

                return Ok(carrinhoDTO);
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
                await _carrinhosService.CreateCarrinhoAsync(carrinho);

                return Ok(new { Message = "Carrinho criado com sucesso", Carrinho = carrinho });
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
                Carrinho carrinho = await _carrinhosService.GetCarrinhoByIdAsync(id);
                await _carrinhosService.RemoveCarrinho(id);

                return Ok(new { Message = "Carrinho excluído com sucesso", Carrinho = carrinho});
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}