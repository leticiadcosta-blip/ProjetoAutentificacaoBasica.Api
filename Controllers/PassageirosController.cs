using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutentificacaoBasica.Api.Data;
using ProjetoAutentificacaoBasica.Api.Models;
using ProjetoAutentificacaoBasica.Api.Models.DTOs;

namespace ProjetoAutentificacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PassageirosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPassageiro(CriarPassageiroDto criarPassageiroDto)
        {
            var novoPassageiro = new Passageiro
            {
                Nome = criarPassageiroDto.Nome,
                Cpf = criarPassageiroDto.Cpf,

            };

            _context.Passageiros.Add(novoPassageiro);
            await _context.SaveChangesAsync();

            return Ok("Passageiro criado com sucesso!");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassageiroinfoDto>>> GetPassageiros([FromQuery] string? nome)
        {
            var passageiros = await _context.Passageiros
                .AsNoTracking()
                .Where(p => string.IsNullOrEmpty(nome))
                .OrderBy(p => p.Nome)
                .Select(p => new PassageiroinfoDto
                {
                    Id = p.Id,
                    codigo = p.Nome,

                })
                .ToListAsync();

            return Ok(passageiros);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<PassageiroinfoDto>> GetPassageiroPorCpf(string cpf)
        {
            var passageiro = await _context.Passageiros.AsNoTracking()
                .Where(p => p.Cpf == cpf).Select(p => new PassageiroinfoDto
                {
                    Id = p.Id,
                    codigo = p.Nome
                }).FirstOrDefaultAsync();


            if (passageiro is null)
            {
                return NotFound(new { mensagem = "Passageiro não encontrado" });
            }


            return Ok(passageiro);
        }
    }
    }

