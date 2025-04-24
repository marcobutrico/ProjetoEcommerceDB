using System.Linq;
using API_Ecommerce.Context;
using API_Ecommerce.DTO;
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
            //Encontre o produto que desejo
            Cliente clienteEncontrado = _context.Clientes.Find(id);
            //Caso nao encontrado, lanço um erro
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }
            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.Senha = cliente.Senha;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();


        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            //Where - traz todos que atendem uma condicao
            //var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
            var listaClientes = _context.Clientes
            .Where(c => c.NomeCompleto.Contains(nome))
            .ToList();

            return listaClientes;
        }


        //DTO (Data Transfer Object) - classe que oculta informacoes (exemplo senha de cliente
        //Cadastrar ou Editar (DTO)
        // Listar ViewModel -> DTO)

        ////<sumary>
        ////Acessa o Banco de Dados, e encontra o Cliente com email e senha fornecidos
        ////</sumary>
        ////<returns>Um cliente ou nulo</returns>
        public Cliente? BuscarPorEmailSenha(string email, string senha)     //? reporta que pode ser nulo
        {
            //Encontrar cliente que possui o email e senha fornecidos
            Cliente clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDto dtocliente)
        {

            Cliente clienteCadastro = new Cliente
            {
                NomeCompleto = dtocliente.NomeCompleto,
                Email = dtocliente.Email,
                Telefone = dtocliente.Telefone,
                Endereco = dtocliente.Endereco,
                Senha = dtocliente.Senha,
                DataCadastro = dtocliente.DataCadastro,
            };

            _context.Clientes.Add(clienteCadastro);
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
            return _context.Clientes
                .OrderBy(c => c.NomeCompleto)
                .ToList();
        }

    }
}
