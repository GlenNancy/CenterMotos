using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.Data;
using CenterMotosApi.Models;
using CenterMotosApi.DTO;


namespace CenterMotosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MecanicosController : ControllerBase
    {
        private readonly DataContext _context;

        public MecanicosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Mecanico mecanico = await _context.Mecanicos.FirstOrDefaultAsync(p => p.Id == id);
                MecanicoDTO mecanicoDTO = mecanico.ToMecanico();

                if (mecanico == null)
                {
                    return NotFound("Mecânico não encontrado");
                }

                return Ok(mecanicoDTO);
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
                List<Mecanico> mecanico = await _context.Mecanicos.ToListAsync();
                IEnumerable<MecanicoDTO> mecanicoDTO = mecanico.Select(m => m.ToMecanico());

                if (!mecanicoDTO.Any())
                {
                    return NotFound("Nenhum mecânico encontrado.");
                }

                return Ok(mecanicoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost("RegistrarMecanico")]
        public async Task<IActionResult> RegistrarMecanicoAsync([FromBody] Mecanico mecanico)
        {
            try
            {
                if (mecanico == null)
                {
                    return BadRequest("O mecânico enviado é nulo.");
                }

                Mecanico mecanicoExistente = await _context.Mecanicos.FirstOrDefaultAsync(p => p.Cpf == mecanico.Cpf);

                if (mecanicoExistente != null)
                {
                    return BadRequest("O usuario com este CPF já existe");
                }

                if (mecanico.Cpf.Length != 11)
                {
                    return BadRequest("O CPF precisa ter 11 caracteres");
                }

                if (mecanico.Nome.Length <= 2)
                {
                    return BadRequest("O nome deve ter no mínimo 3 caracteres.");
                }

                if (await _context.Mecanicos.AnyAsync(p => p.Nome == mecanico.Nome))
                {
                    return BadRequest("O usuario com este Nome já existe");
                }

                if (mecanico.Senha.Length < 6)
                {
                    return BadRequest("A senha deve ter pelo menos 6 caracteres");
                }

                if (!mecanico.Senha.Any(char.IsDigit))
                {
                    return BadRequest("A senha deve conter pelo menos um número");
                }

                if (!mecanico.Senha.Any(char.IsUpper))
                {
                    return BadRequest("A senha deve conter pelo menos uma letra maiúscula");
                }

                await _context.Mecanicos.AddAsync(mecanico);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Mecânico registrado com sucesso", Mecanico = mecanico });

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizarNome/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mecanico mecanicoAtualizado)
        {
            try
            {
                Mecanico mecanicoExistente = await _context.Mecanicos.FindAsync(id);

                if (mecanicoExistente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                if (mecanicoAtualizado == null)
                {
                    return BadRequest("O objeto de cliente é nulo.");
                }

                mecanicoExistente.Nome = mecanicoAtualizado.Nome;

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Mecânico atualizado com sucesso", Cliente = mecanicoExistente });
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
                Mecanico mecanico = await _context.Mecanicos.FirstOrDefaultAsync(delete => delete.Id == id);

                if (mecanico == null)
                {
                    return NotFound("Mecânico não encontrado");
                }

                _context.Mecanicos.Remove(mecanico);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Cliente excluído com sucesso", Mecanico = mecanico });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}