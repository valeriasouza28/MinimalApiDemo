using MinimalApiDemo.Dominio.Entidades;

namespace MinimalApiDemo.Dominio.Interfaces;

public interface IVeiculoServico {
     //método retorna administrador podendo ser nulo
 List<Veiculo> Todos(int? pagina, string? nome = null, string? marca = null);
    Veiculo? BuscaPorId(int id);

    void Incluir(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Apagar(Veiculo veiculo);



}