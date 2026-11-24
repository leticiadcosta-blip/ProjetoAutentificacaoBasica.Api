using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAutentificacaoBasica.Api.Data;
using ProjetoAutentificacaoBasica.Api.Models;
using ProjetoAutentificacaoBasica.Api.Models.DTOs;

namespace ProjetoAutentificacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;


        public AuthController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var novousuario = new Usuario
            {
                Nome = registerDto.Nome,
                Username = registerDto.Username,
                password = registerDto.Password,
                CreatedAt = DateTime.Now
            };
            _context.Usuarios.Add(novousuario);
            await _context.SaveChangesAsync();
            return Ok("Usuário criadof com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (usuario == null || usuario.password != loginDto.Password)
            {
                return NotFound("Credenciais inválidas!");
            }
            return Ok("Login realizado com sucesso!");
        }
    }

}
