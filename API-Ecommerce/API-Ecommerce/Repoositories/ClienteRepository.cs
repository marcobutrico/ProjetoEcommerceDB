using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using API_Ecommerce.Services;
using API_Ecommerce.ViewModels;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    // 1 - Herda da Interface
    // 2 - Implementa a Interface
    // 3 - Injetar o Contexto
    public class ClienteRepository : IClienteRepository
    {
        // 4 - Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        // Ação de Injetar

        // Metodo Construtor - É um metodo que tem o mesmo nome da classe
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }


        public List<ListarClienteViewModel> ListarTodos()
        {
            // Select permite que eu selecione quais campos eu quero pegar
            return _context.Clientes.Select(c => new ListarClienteViewModel
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Endereco = c.Endereco,
                Telefone = c.Telefone,
                Email = c.Email,
            }).ToList();
        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            //Where - traz todos que atendem uma condicao
            //var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto.Contains(nome)).ToList();

            return listaClientes;
        }

        /// <summary>
        /// Vai acessar o Banco de Dados e Encontra o Cliente com E-mail e Senha fornecidos
        /// </summary>
        /// <returns>Um cliente ou null</returns>

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email);

            //caso nao encontre, retorna nulo
            if (clienteEncontrado == null)
                return null;

            var passwordService = new PasswordService();
            //verificar se a Senha do usuario gera o mesmo hash
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);
            if (resultado == true) return clienteEncontrado;
            return null;

        }


        public void Atualizar(int id, CadastrarClienteDto clienteDto)
        {
            var passwordService = new PasswordService();
            var clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            // Atualize as propriedades do cliente com o DTO
            clienteEncontrado.NomeCompleto = clienteDto.NomeCompleto;
            clienteEncontrado.Email = clienteDto.Email;
            clienteEncontrado.Senha = clienteDto.Senha;
            clienteEncontrado.Telefone = clienteDto.Telefone;
            clienteEncontrado.Endereco = clienteDto.Endereco;
            clienteEncontrado.DataCadastro = clienteDto.DataCadastro;

            clienteEncontrado.Senha = passwordService.HashPassword(clienteEncontrado);

            _context.SaveChanges();
        }



        public void Cadastrar(CadastrarClienteDto cliente)
        {
            var passwordService = new PasswordService();

            Cliente clienteCadastrar = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                Senha = cliente.Senha,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now)
            };

            clienteCadastrar.Senha = passwordService.HashPassword(clienteCadastrar);

            _context.Clientes.Add(clienteCadastrar);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            _context.Clientes.Remove(clienteEncontrado);

            _context.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }


    }
}
