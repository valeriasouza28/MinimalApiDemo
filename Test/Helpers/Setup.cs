using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.Entidades.Servicos;
using MinimalApiDemo.Dominio.Interfaces;
using MinimalApiDemo.Infraestrutura.Db;
// using Test.Domain.Servico;
using Test.Mocks;

namespace Test.Helpers;

public class Setup {
    public const string POERT ="5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext){
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder => {
            builder.UseSetting("https_port", Setup.POERT).UseEnvironment("Testing");

            builder.ConfigureServices(services => {
                
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                services.AddScoped<IVeiculoServico, VeiculoServicoMock>();

            });
        });
        Setup.client = Setup.http.CreateClient();

    }


    internal static void ClassCleanup()
    {
         if (Setup.client != null) {
            Setup.client.Dispose();
            Setup.client = null!;
        }

        if (Setup.http != null) {
            Setup.http.Dispose();
            Setup.http = null!;
        }

        if (Setup.testContext != null) {
            Setup.testContext = null!;
        }
    }
}