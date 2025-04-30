using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using API_Ecommerce.Services;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IClienteRepository _clienteRepository;

        //Instanciar o PasswordService
        private PasswordService passwordService = new PasswordService();

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET
        [HttpGet]
        [Authorize]
        public IActionResult ListarClientes()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDto cliente)
        {
           
            //1 - Coloco o Cliente no Banco de Dados
            _clienteRepository.Cadastrar(cliente);

            //Retorna o resultado
            //201 - Created
            return Created();
        }


        // Buscar Cliente por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(cliente);
        }


        // Deleta Produto por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Cliente não encontrado!");
            }
        }



        // Edita Produto por ID
        [HttpPut("{id}")]
        public IActionResult Editar(int id, CadastrarClienteDto cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok(cliente);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }


        //Buscar por email e senha
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (cliente == null)
            {
                return Unauthorized("Email ou Senha inválidos!");
            }

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(cliente.Email);
            var json = new { Token = token };

            return Ok(json);

        }

        //Buscar por nome
        // /api/cliente/joao
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var cliente = _clienteRepository.BuscarClientePorNome(nome);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);

        }



    }

}


