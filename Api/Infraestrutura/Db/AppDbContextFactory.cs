using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MinimalApiDemo.Infraestrutura.Db
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<DbContexto>
    {
        public DbContexto CreateDbContext(string[] args)
        {
            // Carrega as configurações do arquivo appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false) // Certifique-se de que o arquivo é obrigatório
                .Build();

            // Cria o DbContextOptionsBuilder e configura a string de conexão
            var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));

            // Retorna o DbContexto com os dois parâmetros exigidos (DbContextOptions e IConfiguration)
            return new DbContexto(optionsBuilder.Options, configuration);
        }
    }
}


// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System.IO;

// namespace MinimalApiDemo.Infraestrutura.Db
// {
//     public class AppDbContextFactory : IDesignTimeDbContextFactory<DbContexto>
//     {
//         public DbContexto CreateDbContext(string[] args)
//         {

           
//         var configuration = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json", optional: false) // Certifique-se de que o arquivo é obrigatório
//             .Build();

//         var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
//         var connectionString = configuration.GetConnectionString("DefaultConnection");

//         optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));

//         return new DbContexto(optionsBuilder.Options);
//     }
           
//         }
//     }

