using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;

namespace API_Ecommerce.Repoositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        // Metodos que acessam o banco de dados

        //Injetar o contexto Context 
        // Injecao de dependencia

        //salva o conteudo de Context
        private readonly EcommerceContext _context;



        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itempedido)
        {
            throw new NotImplementedException();
        }


        public void Cadastrar(ItemPedido itempedido)
        {
            _context.ItemPedidos.Add(itempedido);
            //throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
            //throw new NotImplementedException();
        }

        ItemPedido IItemPedidoRepository.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
