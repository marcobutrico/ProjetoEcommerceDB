using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;

namespace API_Ecommerce.Repoositories
{
    public class PedidoRepository : IPedidoRepository
    {
        // Metodos que acessam o banco de dados

        //Injetar o contexto Context 
        // Injecao de dependencia

        //salva o conteudo de Context
        private readonly EcommerceContext _context;



        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarPedidoDto pedido)
        {
            //Encontre o produto que desejo
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);
            //Caso nao encontrado, lanço um erro
            if (pedidoEncontrado == null)
            {
                throw new Exception();
            }
            pedidoEncontrado.DataPedido = pedido.DataPedido;
            pedidoEncontrado.StatusPedido = pedido.StatusPedido;
            pedidoEncontrado.ValorTotal = pedido.ValorTotal;
            pedidoEncontrado.IdCliente = pedido.IdCliente;

            _context.SaveChanges();
        }

        public void Cadastrar(CadastrarPedidoDto pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }




        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(e => e.IdPedido == id);
        }



         public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.Include(p => p.ItemPedidos).ThenInclude(c=>c.NomeProduto).ToList();
        }

    }
}
