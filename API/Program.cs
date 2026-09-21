//1- Criar solucao
//2- Entrar na pasta da solucao
//3- Criar o projeto
//4- Vincular o projeto para a solucao
using API.Models;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new List<Product>(){
    new Product { Name = "Placa-mãe ASUS ROG Strix B550-F" },
    new Product { Name = "Processador AMD Ryzen 7 5800X" },
    new Product { Name = "Memória RAM Corsair Vengeance 16GB DDR4" },
    new Product { Name = "SSD NVMe Kingston NV2 1TB" },
    new Product { Name = "Placa de Vídeo NVIDIA GeForce RTX 4070" },
    new Product { Name = "Fonte Corsair RM750x 750W 80 Plus Gold" },
    new Product { Name = "Gabinete Cooler Master MasterBox TD500" },
    new Product { Name = "Water Cooler Corsair iCUE H100i" },
    new Product { Name = "Monitor LG UltraGear 27 165Hz" },
    new Product { Name = "Fone Headset Gamer HyperX Cloud II" }
};

//FUNCIONALIDADES - EndPoint
//Requisicoes
//----METODO HTTP
//----URL
//Respostas
//----Date/informacao


//GET: /http://localhost:5287/
app.MapGet("/", () => "API ECOMMERCE!");

//GET: /api/product/listar
app.MapGet("/api/product/list", () => {
    return products;
});

app.MapPost("/api/product/cadastrar", (Product product) =>
{
    products.Add(product);
    return                                          //Porque estou retornando o produto que recebi?
    Results.Created("", product);               //Retorna o produto para que o cliente saiba exatamente o que foi persistido
});


app.Run();


//Product product = new Product()
//product.Name = "TECLADO"
//Console.WriteLine(product.Name())
