#Passo a passo para a implementacao de API C# com Swagger
- Após implementar o banco de dados conforme diagrama: (DDL e DML).

1. No Microsoft Visual Studio, abra uma novo Projeto, do tipo: API - ASP Core Vazio
2. Instalando os pacotes iniciais:  No menu superior Projeto > Gerenciar do Projeto NuGet
     - Microsoft.EntityFrameworkCore.Design
     - Microsoft.EntityFrameworkCore.SqlServer
     - Microsoft.EntityFrameworkCore.Tools
  
2.1 Realizar o scaffold (database => code):

     dotnet tool install --global dotnet-ef

2.2 Instalar o Entity Framework

     dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models

3. Criar a estrutura da diretorios dentro do projeto:
     -- Controllers
     -- Interfaces
     -- Models
     -- Repositories
4. Criar Iterface
   - Definir métodos CRUD
     
 <code>
 // Fachada - Contrato
public interface IProdutoRepository
{
    // R - Read (Leitura)
    // Retorno
    List<Produto> ListarTodos();
    // Recebe um identificador, e retorna o produto correspondente
    Produto BuscarPorId(int id);

    // C - Create (Cadastro)
    void Cadastrar(Produto produto);

    // U - Update (Atualização)
    // Recebe um identificador para encontrar o Produto, e recebe o Produto Novo para substituir o Antigo
    void Atualizar(int id, Produto produto);

    // D - Delete (Deleção)
    // Recebo o identificador de quem quero excluir
    void Deletar(int id);
}
 </code>

 5. Criar Repository
    - Herdar a Interface
    - Implementar a Interface
    - Criar a Variável Context
    - Injetar o Contexto
    - Implementar métodos

<code> public class ProdutoRepository : IProdutoRepository
{
    // Métodos que acessam o Banco de Dados

    // Injetar o Context
    // Injeção de Dependência
    private readonly EcommerceContext _context;

    // Metodo Construtor
    // Quando criar um objeto o que eu preciso ter?
    public ProdutoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public void Atualizar(int id, Produto produto)
    {
        throw new NotImplementedException();
    }

    public Produto BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Produto produto)
    {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }

    public List<Produto> ListarTodos()
    {
        return _context.Produtos.ToList();
    }
}
</code>

6. Implementar o Controller

<code> 

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{

    private readonly EcommerceContext _context;
    private IProdutoRepository _produtoRepository;        

    public ProdutoController(EcommerceContext context)
    {
        _context = context;
        _produtoRepository = new ProdutoRepository(_context);
    }

    // GET
    [HttpGet]
    public IActionResult ListarProdutos()
    {
        return Ok(_produtoRepository.ListarTodos());
    }

}
</code>

7. Adequar o Program.cs
    - Configurar injecao de dependencia 

<code>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
</code>

8. Instalando os pacotes do SWAGGER:  No menu superior Projeto > Gerenciar do Projeto NuGet
    - Swashbucle.AspNetCore.SwaggerGen
    - Swashbucle.AspNetCore.SwaggerUI
  
9. 7. Adequar o Program.cs para considerar o Swagger
    <code>
    builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

    var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();
    </code>
