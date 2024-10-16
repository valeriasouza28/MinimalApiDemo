using MinimalApiDemo.Dominio.DTOs;
using MinimalApiDemo.Dominio.Entidades;

namespace MinimalApiDemo.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
         //método retorna administrador podendo ser nulo
          
        Administrador? Login(LoginDto loginDto);

        public void Incluir(Administrador administrador);

        List<Administrador> ListarTodos(int? pagina);

         // Novo método para buscar administrador por ID
        Administrador? BuscarPorId(int id);

        // Novo método para atualizar administrador
        void Atualizar(Administrador administrador);

        // Novo método para excluir administrador
        void Apagar(Administrador administrador);
    }
}