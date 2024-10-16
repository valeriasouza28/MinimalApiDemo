using MinimalApiDemo.Infraestrutura.Db;
using MinimalApiDemo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Dominio.Interfaces;

namespace MinimalApiDemo.Dominio.Entidades.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _dbContexto;

    public VeiculoServico (DbContexto dbContexto){
        _dbContexto = dbContexto;
    }

    public void Apagar(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Remove(veiculo);
        _dbContexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Update(veiculo);
        _dbContexto.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _dbContexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();;
    }

    public void Incluir(Veiculo veiculo)
    {
        _dbContexto.Veiculos.Add(veiculo);
        _dbContexto.SaveChanges();
    }

    public List<Veiculo> Todos(int? pagina, string? nome = null, string? marca = null)
    {
        var query = _dbContexto.Veiculos.AsQueryable();

    if (!string.IsNullOrEmpty(nome)) 
    {
        // Corrigido o nome da variável e a interpolação
        query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
    }

    int ItemsPorPagina = 10;

    if(pagina != null){

    query = query.Skip(((int)pagina - 1) * ItemsPorPagina).Take(ItemsPorPagina) ;
    }
        return query.ToList();
    
    }
    }
}