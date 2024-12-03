using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.Entidades.Servicos;
using MinimalApiDemo.Infraestrutura.Db;

namespace Test.Domain.Servico;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();

        return new DbContexto(optionsBuilder.Options, configuration);
    }


    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        context.SaveChanges();

        // Assert
        Assert.AreEqual(1, administradorServico.ListarTodos(1).Count());
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        context.SaveChanges();
        var admDoBanco = administradorServico.BuscarPorId(adm.Id);

        // Assert
        Assert.IsNotNull(admDoBanco); // Verifique se o administrador não é nulo
        Assert.AreEqual(1, admDoBanco?.Id);
    }

    [TestMethod]
public void TestandoConexaoComBancoDeTeste()
{
    var context = CriarContextoDeTeste();
    var connectionString = context.Database.GetDbConnection().ConnectionString;

    Assert.IsTrue(connectionString.Contains("minimalapi_test"));
}

}