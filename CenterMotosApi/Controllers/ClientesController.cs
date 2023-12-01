using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;


namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Cliente cliente = await _context.Clientes
                .Include(p => p.Comentarios)
                .Include(p => p.Carrinho)  // Inclua a propriedade Carrinho
                .ThenInclude(c => c.ItensCarrinho)  // Inclua os itens do carrinho
                .FirstOrDefaultAsync(p => p.Id == id);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

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
                List<Cliente> lista = await _context.Clientes
                .Include(p => p.Comentarios)
                .Include(p => p.Carrinho) 
                .ThenInclude(c => c.ItensCarrinho)
                .ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhum cliente encontrado.");
                }

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
                if (cliente == null)
                {
                    return BadRequest("O cliente enviado é nulo.");
                }

                Cliente clienteExistente = await _context.Clientes.FirstOrDefaultAsync(p => p.Cpf == cliente.Cpf);

                if (clienteExistente != null)
                {
                    return BadRequest("O usuario com este CPF já existe");
                }

                if (cliente.Cpf.Length != 11)
                {
                    return BadRequest("O CPF precisa ter 11 caracteres");
                }

                if (cliente.Nome.Length <= 2)
                {
                    return BadRequest("O nome deve ter no mínimo 3 caracteres.");
                }

                if (await _context.Clientes.AnyAsync(p => p.Nome == cliente.Nome))
                {
                    return BadRequest("O usuario com este Nome já existe");
                }

                if (cliente.Senha.Length < 6)
                {
                    return BadRequest("A senha deve ter pelo menos 6 caracteres");
                }

                if (!cliente.Senha.Any(char.IsDigit))
                {
                    return BadRequest("A senha deve conter pelo menos um número");
                }

                if (!cliente.Senha.Any(char.IsUpper))
                {
                    return BadRequest("A senha deve conter pelo menos uma letra maiúscula");
                }

                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();

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
                Cliente clienteExistente = await _context.Clientes.FindAsync(id);

                if (clienteExistente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                if (clienteAtualizado == null)
                {
                    return BadRequest("O objeto de cliente é nulo.");
                }

                clienteExistente.Nome = clienteAtualizado.Nome;

                // Atualizar o nome em todos os comentários associados ao cliente
                List<Comentario> lista = await _context.Comentarios
                    .Where(c => c.ClienteId == id)
                    .ToListAsync();

                if (lista.Count == 0)
                {
                    return NotFound("Nenhum comentário encontrado.");
                }

                foreach (var comentario in lista)
                {
                    comentario.Nome = clienteAtualizado.Nome;
                }

                await _context.SaveChangesAsync();

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
                Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(delete => delete.Id == id);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Cliente excluído com sucesso", Cliente = cliente });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}