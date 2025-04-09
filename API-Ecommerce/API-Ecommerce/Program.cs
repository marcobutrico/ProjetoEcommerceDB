//Permitem que se construa a aplicacao ... 
//ASP Core Vazio
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//dotnet tool install --global dotnet-ef
//Instala as ferraments de terminal do Entity Framework


//Roda a aplicacao
app.Run();
