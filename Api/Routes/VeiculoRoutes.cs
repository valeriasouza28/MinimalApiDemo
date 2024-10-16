// using MinimalApiDemo.Dominio.DTOs;
// using MinimalApiDemo.Dominio.Entidades.Servicos;
// using MinimalApiDemo.Dominio.Interfaces;
// using Microsoft.AspNetCore.Authorization;
// using MinimalApiDemo.Dominio.ModelViews;
// using MinimalApiDemo.Dominio.Entidades;
// using Microsoft.AspNetCore.Mvc;

// namespace MinimalApiDemo.Routes
// {
//     public static class VeiculoRoutes
//     {
//         private static ErrosValidacao validaDto(VeiculoDto veiculoDto) {
//     var validacao = new ErrosValidacao{
//         Mensagens = new List<string>()
//     };

//     if(string.IsNullOrEmpty(veiculoDto.Nome))
//         validacao.Mensagens.Add("O Nome não pode ser vazio");

//     if(string.IsNullOrEmpty(veiculoDto.Marca))
//         validacao.Mensagens.Add("A Marca não pode ser vazia");

//     if(veiculoDto.Ano <= 1950)
//         validacao.Mensagens.Add("O ano deve ser superior 1950");
//         return validacao;

// }
        
//         public static void MapRoutes(IEndpointRouteBuilder endpoints)
//         {
//             // Rota para adicionar veículos
//             endpoints.MapPost("/veiculos", (VeiculoDto veiculoDto, IVeiculoServico veiculoServico) =>
//             {
//                 // Validação e inserção de veículo
//                 var validacao = validaDto(veiculoDto);
//                 if (validacao.Mensagens.Count > 0) return Results.BadRequest(validacao);
                
//                 var veiculo = new Veiculo { Nome = veiculoDto.Nome, Marca = veiculoDto.Marca, Ano = veiculoDto.Ano };
//                 veiculoServico.Incluir(veiculo);
//                 return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
//             })
//             .WithTags("Veículos")
//             .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

//             // Outras rotas relacionadas a veículos...

//             endpoints.MapGet("/veiculos", [Authorize] ([FromQuery] int? pagina, IVeiculoServico veiculoServico) => {
    
// var veiculos = veiculoServico.Todos(pagina);

//     return Results.Ok(veiculos);

// })
// .WithTags("Veiculos")
// .WithName("GetTodosVeiculos")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin, Editor"});;

// endpoints.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico)  => {
//     var veiculo = veiculoServico.BuscaPorId(id);
//     return veiculo != null ? Results.Ok(veiculo) : Results.NotFound();
// })
// .WithTags("Veiculos")
// .WithName("BuscaVeiculoPorId")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin, Editor"});

// endpoints.MapPut("/veiculos/{id}", ( [FromRoute]  int id, IVeiculoServico veiculoServico,VeiculoDto veiculoDto) =>
// {

//     var veiculoExistente = veiculoServico.BuscaPorId(id);
//     if (veiculoExistente == null) return Results.NotFound();

//     var validacao = validaDto(veiculoDto);

//     if(validacao.Mensagens.Count > 0)
//         return Results.BadRequest(validacao);

   

//     veiculoExistente.Nome = veiculoDto.Nome;
//     veiculoExistente.Marca = veiculoDto.Marca;
//     veiculoExistente.Ano = veiculoDto.Ano;

//     veiculoServico.Atualizar(veiculoExistente);
//     return Results.Ok(veiculoExistente);
// })
// .WithTags("Veículos")
// .WithName("PutVeiculo")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin"});


// endpoints.MapDelete("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) =>
// {
//     var veiculo = veiculoServico.BuscaPorId(id);
//     if (veiculo == null) return Results.NotFound();

//     veiculoServico.Apagar(veiculo);
//     return Results.NoContent();
// })
// .WithTags("Veículos")
// .WithName("DeleteVeiculo")
// .RequireAuthorization(new AuthorizeAttribute {Roles = "Admin"});


//         }
//     }

 
// }
