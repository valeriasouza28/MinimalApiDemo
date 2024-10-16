using MinimalApiDemo.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTest {
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var adm = new Administrador();

        //Act
        adm.Id = 1;
        adm.Email = "test@teste.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";

        //Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("test@teste.com", adm.Email);
        Assert.AreEqual("123456", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }

}