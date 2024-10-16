namespace MinimalApiDemo.Dominio.ModelViews;

public record AdministardorLogado {
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
    public string Token { get; set; } = default!;

}