// using MinimalApiDemo.Dominio.DTOs;
// using MinimalApiDemo.Dominio.Entidades.Servicos;
// using MinimalApiDemo.Dominio.Interfaces;
// using MinimalApiDemo.Dominio.ModelViews;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using MinimalApiDemo.Dominio.Entidades;

// namespace MinimalApiDemo.Routes
// {
//     public static class AdministradorRoutes
//     {

//         private static ErrosValidacao validaAdministradorDto (AdministradorDto administradorDto) {
//             var validacao = new ErrosValidacao {
//                 Mensagens = new List<string>()
//             };

//             if(string.IsNullOrEmpty(administradorDto.Email))
//             validacao .Mensagens.Add("O Email não pode ser vazio");

//             if(string.IsNullOrEmpty(administradorDto.Senha))
//             validacao .Mensagens.Add("A Senha não pode ser vazia");

//             if(string.IsNullOrEmpty(administradorDto.Perfil))
//             validacao .Mensagens.Add("O Perfil não pode ser vazio");

//             return validacao;

//         }

//         // [ ] todo: concertar o uso do método GenerateTokens
//         public static void MapRoutes(IEndpointRouteBuilder endpoints)
//         {
//             // Rota para login de administradores
//             endpoints.MapPost("/administradores/login", ([FromBody] LoginDto loginDto, IAdministradorServico administradorServico, IJwtTokenService jwTokenService) =>
//             {
//                 var admin = administradorServico.Login(loginDto);
//                 if (admin != null)
//                 {
//                     // TokenJWT implementado no Startup
//                     // new Startup(endpoints.ServiceProvider.GetRequiredService<IConfiguration>()).
//                     var token = jwTokenService.GenerateJwtToken(admin);
//                     Console.WriteLine(token); 
//                     return Results.Ok(new AdministardorLogado { Email = admin.Email, Perfil = admin.Perfil, Token = token });
//                 }
//                 else
//                     return Results.Unauthorized();
//             }).AllowAnonymous().WithTags("AdministradorLogin");

//             // Outras rotas relacionadas a administradores...

//             endpoints.MapPost("/administradores", ([FromBody] AdministradorDto administradorDto, IAdministradorServico administradorServico) => {

//     var validacao = validaAdministradorDto(administradorDto);

//     if(validacao.Mensagens.Count > 0)
//         return Results.BadRequest(validacao);
    
//     var administrador = new Administrador {
//         Email = administradorDto.Email,
//         Senha = administradorDto.Senha,
//         Perfil = administradorDto.Perfil
//     };

//     administradorServico.Incluir(administrador);

//     return Results.Created($"/administradores/{administrador.Id}", administrador);


// })
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin"})
// .WithTags("AdministradorLogin")
// .WithName("PostAdministrador");

// endpoints.MapGet("/administradores", (IAdministradorServico administradorServico) => {

//     var administradores = administradorServico.ListarTodos();

//     if(administradores.Any())
//         return Results.Ok(administradores);

//     return Results.NotFound("Nenhum administrador encontrado.");

// })
// .RequireAuthorization().RequireAuthorization(new AuthorizeAttribute {Roles = "Admin, Editor"})
// .WithTags("Administradores")
// .WithName("GetAdministradores");

// // Buscar administrador por ID
// endpoints.MapGet("/administradores/{id}", (int id, IAdministradorServico administradorServico) =>
// {
//     var administrador = administradorServico.BuscarPorId(id);
//     return administrador != null ? Results.Ok(administrador) : Results.NotFound();
// })
// .WithTags("Administradores")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin, Editor"});

// // Atualizar administrador por ID
// endpoints.MapPut("/administradores/{id}", (int id, AdministradorDto administradorDto, IAdministradorServico administradorServico) =>
// {
//     var administradorExistente = administradorServico.BuscarPorId(id);
//     if (administradorExistente == null)
//         return Results.NotFound();

//     administradorExistente.Email = administradorDto.Email;
//     administradorExistente.Senha = administradorDto.Senha;
//     administradorExistente.Perfil = administradorDto.Perfil;

//     administradorServico.Atualizar(administradorExistente);
//     return Results.Ok(administradorExistente);
// })
// .WithTags("Administradores")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin"});

// // Excluir administrador por ID
// endpoints.MapDelete("/administradores/{id}", (int id, IAdministradorServico administradorServico) =>
// {
//     var administrador = administradorServico.BuscarPorId(id);
//     if (administrador == null)
//         return Results.NotFound();

//     administradorServico.Apagar(administrador);
//     return Results.NoContent();
// })
// .WithTags("Administradores")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin"});

//         }
//     }
// }
