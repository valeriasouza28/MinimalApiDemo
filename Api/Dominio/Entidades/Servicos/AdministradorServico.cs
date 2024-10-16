using System.Data.Common;
using MinimalApiDemo.Dominio.DTOs;
using MinimalApiDemo.Dominio.Interfaces;
using MinimalApiDemo.Infraestrutura.Db;

namespace MinimalApiDemo.Dominio.Entidades.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _dbContexto;

    public AdministradorServico (DbContexto dbContexto){
        _dbContexto = dbContexto;
    }

    //implementa o método da interface IAdministrador
    public Administrador? Login(LoginDto loginDto)
    {
        var qtd = _dbContexto.Administradores.Where(a => a.Email == loginDto.Email && a.Senha == loginDto.Senha)
        .FirstOrDefault();
        return qtd;
    }

    public void Incluir(Administrador administrador) {
        _dbContexto.Administradores.Add(administrador);
        _dbContexto.SaveChanges();
    }

    public List<Administrador> ListarTodos(int? pagina)  // Implementação do método para listar todos os administradores
    {
        var query = _dbContexto.Administradores.AsQueryable();

        int itensPorPagina = 10;

        if(pagina != null)
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }

     // Novo método para buscar administrador por ID
    public Administrador? BuscarPorId(int id)
    {
        return _dbContexto.Administradores.Find(id);
    }

    // Novo método para atualizar administrador
    public void Atualizar(Administrador administrador)
    {
        _dbContexto.Administradores.Update(administrador);
        _dbContexto.SaveChanges();
    }

    // Novo método para excluir administrador
    public void Apagar(Administrador administrador)
    {
        _dbContexto.Administradores.Remove(administrador);
        _dbContexto.SaveChanges();
    }
}