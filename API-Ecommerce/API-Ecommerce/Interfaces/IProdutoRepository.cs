
// Passo a passo da API

// 1 - Instalar os pacotes do Entity Framework <Core.Design> <Core.SqlServer> <Core.Tools>

// 2 - Realizar o Scaffold <dotnet tool install --global dotnet-ef>
// dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models

// 3 - Criar as pastas <Interfaces> <Repositories> <Controllers>

// 4 - Criar a interface, de cada model

// 5 - Criar a repository, de cada model

// 6 - Criar o Controller, de cada model

// 7 - Instalar pelo NuGet o Swagger: SwaggerGen e SwaggerUI


using API_Ecommerce.DTO;
using API_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Interfaces
{
    public interface IProdutoRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar produtos - Read all
        List<Produto> ListarTodos();

        //CRUD
        //Listar produtos por Id - Read {id}
        //Recebe um Id e retorna o produto correspondente
        Produto BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Produto       produto (argumento)
        void Cadastrar(CadastrarProdutoDto produto);    //modificando de Produto para CadastrarProdutoDto 


        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o produto correspondente
        void Atualizar(int id, Produto produto); //modificando de Produto para CadastrarProdutoDto 

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o produto correspondente
        void Deletar(int id);
    }
}
