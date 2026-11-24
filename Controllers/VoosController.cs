using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutentificacaoBasica.Api.Data;
using ProjetoAutentificacaoBasica.Api.Models;
using ProjetoAutentificacaoBasica.Api.Models.DTOs;

namespace ProjetoAutentificacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CriarVoo(CriarVooDto criarVooDto)
        {
            var novoVoo = new voo
            {
                codigo = criarVooDto.codigo,
                Origem = criarVooDto.Origem,
                Destino = criarVooDto.Destino

            };

            _context.Voos.Add(novoVoo);
            await _context.SaveChangesAsync();

            return Ok("Voo criado com sucesso!");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumoVooDto>>> GetVoos()
        {
            var voos = await _context.Voos
                .AsNoTracking()
                .OrderBy(v => v.codigo)
                .Select(v => new ResumoVooDto
                {
                    Id = v.Id,
                    codigo = v.codigo,
                    Trajeto = v.Origem + "->" + v.Destino
                })
                .ToListAsync();

            return Ok(voos);
        }
        [HttpGet("voo/{voo}")]
        public async Task<ActionResult<ResumoVooDto>> GetPassageiroPorVoo(string voo)
        {
           
            if (!int.TryParse(voo, out int codigoVoo))
            {
                return BadRequest(new { mensagem = "Código de voo inválido." });
            }

            var vooEncontrado = await _context.Voos.AsNoTracking()
                .Where(v => v.codigo == codigoVoo) 
                .Select(v => new ResumoVooDto
                {
                    Id = v.Id,
                    codigo = v.codigo,
                    Trajeto = v.Origem + "->" + v.Destino
                })
                .FirstOrDefaultAsync();

            if (vooEncontrado is null)
            {
                return NotFound(new { mensagem = "voo não encontrado" });
            }

            return Ok(vooEncontrado);
        }

    }
}