using API_Ecommerce.DTO;
using API_Ecommerce.Models;
using API_Ecommerce.ViewModels;

namespace API_Ecommerce.Interfaces
{
    public interface IClienteRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar clientes - Read all
        List<ListarClienteViewModel> ListarTodos();

        //CRUD
        //Listar clientes por Id - Read {id}
        //Recebe um Id e retorna o cliente correspondente
        Cliente BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Cliente       cliente (argumento)
        void Cadastrar(CadastrarClienteDto cliente);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o cliente correspondente
        void Atualizar(int id, CadastrarClienteDto cliente);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o cliente correspondente
        void Deletar(int id);

        ListarClienteViewModel? BuscarPorEmailSenha(string email, string senha);

        //Buscar cliente por nome
        List<ListarClienteViewModel> BuscarClientePorNome(string nome);
    }



}
