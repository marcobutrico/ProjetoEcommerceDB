using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

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
            Pedido pedidoCadastrar = new Pedido
            {
                DataPedido = pedido.DataPedido,
                StatusPedido = pedido.StatusPedido,
                IdCliente = pedido.IdCliente,
                ValorTotal = pedido.ValorTotal,
            };
            _context.Pedidos.Add(pedidoCadastrar);

            _context.SaveChanges();

            // Cadastrar os ItensPedidos
            // Para cada produto, eu crio um ItemPedido
            // Percorre uma lista/vetor ["mouse", "teclado"]
            for (int i = 0; i < pedido.Produtos.Count; i++)
            {
                // Encontra o produto
                var produto = _context.Produtos.Find(pedido.Produtos[i]);

                // TO-DO: Lançar erro se produto não existir

                // Criando uma váriavel para armazenar os itens do pedido - ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedidoCadastrar.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                // Joga no banco de dados
                _context.ItemPedidos.Add(itemPedido);
                // Salva no banco
                _context.SaveChanges();
            }
        }




        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(e => e.IdPedido == id);
        }



         public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItemPedidos)
                .ThenInclude(ip => ip.IdProdutoNavigation) // Navega de ItemPedido para Produto
                .ThenInclude(prod => prod.NomeProduto)       // Acessa NomeProduto em Produto
                .ToList();
        }

        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
