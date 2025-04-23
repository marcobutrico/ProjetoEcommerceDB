using API_Ecommerce.Context;
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

        public void Atualizar(int id, Pedido pedido)
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

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(e => e.IdPedido == id);
        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.ToList();
            //throw new NotImplementedException();
        }

    }
}
