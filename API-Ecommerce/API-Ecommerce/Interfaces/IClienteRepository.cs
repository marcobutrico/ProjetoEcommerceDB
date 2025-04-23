using API_Ecommerce.Models;

namespace API_Ecommerce.Interfaces
{
    public interface IClienteRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar clientes - Read all
        List<Cliente> ListarTodos();

        //CRUD
        //Listar clientes por Id - Read {id}
        //Recebe um Id e retorna o cliente correspondente
        Cliente BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Cliente       cliente (argumento)
        void Cadastrar(Cliente cliente);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o cliente correspondente
        void Atualizar(int id, Cliente cliente);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o cliente correspondente
        void Deletar(int id);

        Cliente? BuscarPorEmailSenha(string email, string senha);
    }
}
