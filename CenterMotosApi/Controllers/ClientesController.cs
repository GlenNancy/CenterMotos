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
                ClienteDTO clienteDTO = cliente.ToCliente();

                return Ok(clienteDTO);
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
                IEnumerable<Cliente> cliente = await _clientesService.GetAllClienteAsync();
                IEnumerable<ClienteDTO> clienteDTO = cliente.Select(c => c.ToCliente());

                return Ok(clienteDTO);
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

        [HttpPut("AlterarSenha/{id}")]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] Cliente clienteSenhaAtualizada)
        {
            try
            {
                Cliente clienteExistente = await _clientesService.UpdatePasswordClienteAsync(id, clienteSenhaAtualizada);

                return Ok(new { Message = "Senha alterada com suceso", Cliente = clienteExistente});
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