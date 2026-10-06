//1- Criar solucao
//2- Entrar na pasta da solucao
//3- Criar o projeto
//4- Vincular o projeto para a solucao
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

List<Product> products = new List<Product>();

//FUNCIONALIDADES - EndPoint
//Requisicoes
//----METODO HTTP
//----URL
//OPCIONAL: Corpo (Produto q recebemos)/ Parametros de URL para receber informacao (poder manipular)

//Respostas
//----Date/informacao

//GET: http://localhost:5287/
app.MapGet("/", () => "API ECOMMERCE!");

//GET: /api/product/list
//Retorna a lista de produtos (200 com lista vazia quando nao ha produtos)
app.MapGet("/api/product/list", () =>
{
    return Results.Ok(products);
});

//POST: /api/product/cadastrar
app.MapPost("/api/product/cadastrar", ([FromBody] Product? product, [FromServices] AppDataContext ctx) =>
{
    if (product is null)
    {
        return Results.BadRequest("ERROR: produto NULL");
    }

    if (string.IsNullOrWhiteSpace(product.Name))
    {
        return Results.BadRequest("ERROR: Entrada vazia");
    }

    //Verifica se o produto existe na lista
    if (products.Any(p => p.Name == product.Name))
    {
        return Results.BadRequest("ERROR: Produto existente");
    }

    //products.Add(product);
    ctx.Produtos.Add(product);
    ctx.SaveChanges(); //Precisa add para fazer o commit no DB

    //Retorna o produto para que o cliente saiba exatamente o que foi persistido
    return Results.Created("", product);
});

//GET: /api/product/buscar/{name}
app.MapGet("/api/product/buscar", ([FromServices] AppDataContext ctx) =>
{
    //Expressao lambda
    //Product? produtoEncontrado = products.FirstOrDefault(p => p.Name == name);
    if(ctx.Produtos.Count() == 0)
    {
        return Results.BadRequest("ERROR");
    }
    return Results.Ok(ctx.Produtos.ToList());
});

//DELETE: /api/product/remover/{id}
app.MapDelete("/api/product/remover", ([FromServices] AppDataContext ctx) =>
{
    Product? produtoEncontrado = products.FirstOrDefault(p => p.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("ERROR: NOT FOUND");
    }
    //products.Remove(produtoEncontrado);
    ctx.Produtos.Remove(product);
    ctx.SaveChanges();

    return Results.Ok(produtoEncontrado);
});

//PATCH: Alterar produtos | Vem da ROUTE[ID] | VEM DO CORPO [product]
app.MapPatch("/api/product/alterar/{id}", ([FromRoute] string id, [FromBody] Product produtoAlterado) =>
{
    Product? produtoEncontrado = products.FirstOrDefault(p => p.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("ERROR: NOT FOUND");
    }

    if (string.IsNullOrWhiteSpace(produtoAlterado.Name))
    {
        return Results.BadRequest("ERROR: Entrada vazia");
    }

    produtoEncontrado.Name = produtoAlterado.Name;
    return Results.Ok(produtoEncontrado);
});

app.Run();