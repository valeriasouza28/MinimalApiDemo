using System.Text;
using System.Text.Json;
using MinimalApiDemo.Dominio.DTOs;
// using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.ModelViews;

// using Newtonsoft.Json;
using Test.Helpers;

namespace Test.Routes;

[TestClass]
public class AdministradorTest {

    [ClassInitialize]
    public static void ClassInit(TestContext testContext){
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]
    public static void ClassCleanup(){
        Setup.ClassCleanup();
    }

    [TestMethod]
    public async Task TestarGetSetPropriedades() {
        // Verificar se o HttpClient foi inicializado corretamente
        Assert.IsNotNull(Setup.client, "O HttpClient não foi inicializado corretamente.");

        // Arrange
        var loginDto = new LoginDto {
            Email = "adm@example.com",
            Senha = "123456"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

        // Act
        var response = await Setup.client.PostAsync("administradores/login", content);

        // Assert - Verificando se a resposta foi bem-sucedida
        Assert.AreEqual(200, (int)response.StatusCode, "Esperado status code 200 para login bem-sucedido.");

        // Convertendo o conteúdo da resposta para string
        var result = await response.Content.ReadAsStringAsync();

        // Verificando se o conteúdo da resposta foi retornado
        Assert.IsFalse(string.IsNullOrEmpty(result), "A resposta do login não deve ser nula ou vazia.");

        // Deserializando o resultado para o objeto AdministardorLogado
        var admLogado = JsonSerializer.Deserialize<AdministardorLogado>(result, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
        });

        Assert.IsNotNull(admLogado?.Email);
        Assert.IsNotNull(admLogado?.Perfil);

        // Verificando se o objeto foi deserializado corretamente
        Assert.IsNotNull(admLogado, "A deserialização do objeto AdministardorLogado não deve retornar nulo.");

        // Asserts adicionais para verificar as propriedades do objeto
        Assert.AreEqual("adm@example.com", admLogado.Email, "O e-mail do administrador logado não corresponde ao esperado.");
        Assert.IsFalse(string.IsNullOrEmpty(admLogado.Token), "O token de autenticação não deve ser nulo ou vazio.");

        Console.WriteLine(admLogado?.Token);
    }

}