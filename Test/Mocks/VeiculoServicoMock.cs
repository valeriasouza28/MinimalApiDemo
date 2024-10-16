using MinimalApiDemo.Dominio.Entidades;
using MinimalApiDemo.Dominio.Interfaces;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    // Lista estática para simular o banco de dados de veículos
    private static List<Veiculo> veiculos = new List<Veiculo>()
    {
        new Veiculo { Id = 1, Nome = "Fusca", Marca = "Volkswagen", Ano = 1975 },
        new Veiculo { Id = 2, Nome = "Civic", Marca = "Honda", Ano = 2020 },
        new Veiculo { Id = 3, Nome = "Corolla", Marca = "Toyota", Ano = 2019 }
    };

    public void Apagar(Veiculo veiculo)
    {
        var veiculoExistente = veiculos.Find(v => v.Id == veiculo.Id);
        if (veiculoExistente != null)
        {
            veiculos.Remove(veiculoExistente);
        }
    }

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoExistente = veiculos.Find(v => v.Id == veiculo.Id);
        if (veiculoExistente != null)
        {
            veiculoExistente.Nome = veiculo.Nome;
            veiculoExistente.Marca = veiculo.Marca;
            veiculoExistente.Ano = veiculo.Ano;
        }
    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count() + 1;
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina, string? nome = null, string? marca = null)
    {
        var query = veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => v.Nome.ToLower().Contains(nome.ToLower()));
        }

        // Exemplo de paginação
        int ItemsPorPagina = 10;
        if (pagina != null)
        {
            query = query.Skip(((int)pagina - 1) * ItemsPorPagina).Take(ItemsPorPagina);
        }

        return query.ToList();
    }
}
