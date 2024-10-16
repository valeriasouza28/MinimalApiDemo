using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.Entidades.Servicos;

namespace MinimalApiDemo.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration? _configuracaoAppSettings;
    
        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        public DbContexto(DbContextOptions<DbContexto> options, IConfiguration configuracaoAppSettings)
            : base(options) { 
                _configuracaoAppSettings = configuracaoAppSettings;
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador {
                    Id = 1,
                    Email = "Administardor@teste.com",
                    Senha = "123456",
                    Perfil = "Admin"
                }
            );
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _configuracaoAppSettings != null)
            {
                var connectionString = _configuracaoAppSettings.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        
    }
}
