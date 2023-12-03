using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;
using CenterMotosApi.Services;


namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IClientesService _clientesService;

        public ClientesController(DataContext context, IClientesService clientesService)
        {
            _context = context;
            _clientesService = clientesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Cliente cliente = await _clientesService.GetClienteByIdAsync(id);

                return Ok(cliente);
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
                IEnumerable<Cliente> lista = await _clientesService.GetAllClienteAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost("RegistrarCliente")]
        public async Task<IActionResult> RegistrarClienteAsync([FromBody] Cliente cliente)
        {
            try
            {
                await _clientesService.CreateClienteAsync(cliente);

                return Ok(new { Message = "Cliente registrado com sucesso", Cliente = cliente });

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizarNome/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente clienteAtualizado)
        {
            try
            {
                Cliente clienteExistente = await _clientesService.UpdateClienteAsync(id, clienteAtualizado);

                return Ok(new { Message = "Cliente atualizado com sucesso", Cliente = clienteExistente });
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
                Cliente cliente = await _clientesService.GetClienteByIdAsync(id);
                await _clientesService.RemoveCliente(id);

                return Ok(new { Message = "Cliente excluído com sucesso", Cliente = cliente });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}