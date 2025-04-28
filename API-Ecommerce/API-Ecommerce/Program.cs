//Permitem que se construa a aplicacao ... 
    
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Repoositories;
using API_ECommerce.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//O .NET vai cirar os objetos (Injecao de Depend�ncia)
//AddTransient - O C# cria uma instancia nova, toda vez que um m�todo � criado
//AddScoped - O C# cria uma instancia nova, toda vez que criar um controller
//AddSingleton
builder.Services.AddDbContext<EcommerceContext, EcommerceContext>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(); //Constroi a aplica��o.


//app.MapGet("/", () => "Hello World!");

//dotnet tool install --global dotnet-ef
//Instala as ferraments de terminal do Entity Framework

app.MapControllers();

app.Run();

