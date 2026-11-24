using Microsoft.EntityFrameworkCore;
using ProjetoAutentificacaoBasica.Api.Models;


namespace ProjetoAutentificacaoBasica.Api.Data
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }
            public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<passagem> Passagens { get; set; }
        public DbSet<voo> Voos { get; set; }

    }
}