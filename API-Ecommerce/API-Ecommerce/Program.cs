//Permitem que se construa a aplicacao ... 
//ASP Core Vazio
using API_Ecommerce.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


//app.MapGet("/", () => "Hello World!");

//dotnet tool install --global dotnet-ef
//Instala as ferraments de terminal do Entity Framework

app.MapControllers();

app.Run();

