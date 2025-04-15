//Permitem que se construa a aplicacao ... 
    
using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Repoositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


//O .NET vai cirar os objetos (Injecao de Dependência)
//AddTransient - O C# cria uma instancia nova, toda vez que um método é criado
//AddScoped - O C# cria uma instancia nova, toda vez que criar um controller
//AddSingleton

builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


//app.MapGet("/", () => "Hello World!");

//dotnet tool install --global dotnet-ef
//Instala as ferraments de terminal do Entity Framework

app.MapControllers();

app.Run();

