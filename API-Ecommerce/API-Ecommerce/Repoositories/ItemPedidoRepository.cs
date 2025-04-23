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
            //Encontre o produto que desejo
            ItemPedido itempedidoEncontrado = _context.ItemPedidos.Find(id);
            //Caso nao encontrado, lanço um erro
            if (itempedidoEncontrado == null)
            {
                throw new Exception();
            }
            itempedidoEncontrado.IdPedido = itempedido.IdPedido;
            itempedidoEncontrado.IdProduto = itempedido.IdProduto;
            itempedidoEncontrado.Quantidade = itempedido.Quantidade;

            _context.SaveChanges();


        }

        public ItemPedido BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(e => e.IdItem == id);
        }

        public void Cadastrar(ItemPedido itempedido)
        {
            _context.ItemPedidos.Add(itempedido);
            _context.SaveChanges();
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

    }
}
