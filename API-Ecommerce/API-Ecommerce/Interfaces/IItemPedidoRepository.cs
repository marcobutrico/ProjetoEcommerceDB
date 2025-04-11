using API_Ecommerce.Models;

namespace API_Ecommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar itens dos pedidos - Read all
        List<ItemPedido> ListarTodos();

        //CRUD
        //Listar itens de pedido por Id - Read {id}
        //Recebe um Id e retorna o item do pedido correspondente
        ItemPedido BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //ItemPedido       itempedido (argumento)
        void Cadastrar(ItemPedido itempedido);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o item do pedido correspondente
        void Atualizar(int id, ItemPedido itempedido);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o item do pedido correspondente
        void Deletar(int id);
    }
}
