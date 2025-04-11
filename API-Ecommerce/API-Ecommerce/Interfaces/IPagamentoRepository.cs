using API_Ecommerce.Models;

namespace API_Ecommerce.Interfaces
{
    public interface IPagamentoRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar pagamentos - Read all
        List<Pagamento> ListarTodos();

        //CRUD
        //Listar pagamentos por Id - Read {id}
        //Recebe um Id e retorna o pagamento correspondente
        Pagamento BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Pagamento       pagamento (argumento)
        void Cadastrar(Pagamento pagamento);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o produto correspondente
        void Atualizar(int id, Pagamento pagamento);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o pagamento correspondente
        void Deletar(int id);
    }
}
