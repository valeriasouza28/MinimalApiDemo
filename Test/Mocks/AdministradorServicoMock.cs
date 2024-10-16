using System.ComponentModel.DataAnnotations;
using MinimalApiDemo.Dominio.DTOs;
using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.Interfaces;

namespace Test.Mocks;
// todo: create more tests para administrador/login
// todo: criar um mock para veiculos
// todo: buscar melhores praticas para autenticação Jwt
public class AdministradorServicoMock : IAdministradorServico
{
    private static List<Administrador> administradores = new List<Administrador>(){
        new Administrador {Id = 1,
        Email = "adm@example.com",
        Senha = "123456",
        Perfil = "Adm"
        },

        new Administrador {Id = 2,
        Email = "editor@example.com",
        Senha = "123456",
        Perfil = "Editor"
        },
    };

    public void Apagar(Administrador administrador)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Administrador administrador)
    {
        throw new NotImplementedException();
    }

    public Administrador? BuscarPorId(int id)
    {
       return administradores.Find(a => a.Id == id);
    }

    public void Incluir(Administrador administrador)
    {
        administrador.Id = administradores.Count() + 1;
        administradores.Add(administrador);

    }

public List<Administrador> ListarTodos(int? pagina)
    {
        // Definir o tamanho da página (número de administradores por página)
        int tamanhoPagina = 2;

        // Se a página não for especificada, retorna todos os administradores
        if (pagina == null || pagina <= 0)
        {
            return administradores;
        }

        // Cálculo do índice inicial para a página
        int inicio = (pagina.Value - 1) * tamanhoPagina;

        // Se o índice inicial estiver fora do alcance, retorna uma lista vazia
        if (inicio >= administradores.Count)
        {
            return new List<Administrador>();
        }

        // Retorna os administradores da página solicitada
        return administradores.Skip(inicio).Take(tamanhoPagina).ToList();
    }

    public Administrador? Login(LoginDto loginDto)
    {
        return administradores.Find(a => a.Email == loginDto.Email && a.Senha == loginDto.Senha);    
    }
}