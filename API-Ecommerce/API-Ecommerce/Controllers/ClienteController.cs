using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using API_Ecommerce.Repoositories;
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
        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(_context);
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            //1 - Coloco o Cliente no Banco de Dados
            _clienteRepository.Cadastrar(cliente);

            //2. Salvar a alteracao
            _context.SaveChanges();

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
        public IActionResult Editar(int id, Cliente cliente)
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


    }
}

