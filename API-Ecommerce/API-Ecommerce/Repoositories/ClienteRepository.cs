using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;

namespace API_Ecommerce.Repoositories
{
    public class ClienteRepository : IClienteRepository
    {
        // Metodos que acessam o banco de dados

        //Injetar o contexto Context 
        // Injecao de dependencia

        //salva o conteudo de Context
        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }


        public void Atualizar(int id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }


        public void Deletar(int id)
        {
            //1. Encontrar o produto que quero excluir
            //Find. procura pela chave primaria
            Cliente clienteEncontrado = _context.Clientes.Find(id);


            //Caso nao encontrado, lanço um erro
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            _context.Clientes.Remove(clienteEncontrado);

            //Salvo as alteracoes
            _context.SaveChanges();

        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
