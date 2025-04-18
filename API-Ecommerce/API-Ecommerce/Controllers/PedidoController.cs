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
    public class PedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IPedidoRepository _pedidoRepository;
        public PedidoController(EcommerceContext context)
        {
            _context = context;
            _pedidoRepository = new PedidoRepository(_context);
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }


        // Cadastrar Pedidos
        [HttpPost]
        public IActionResult CadastrarPagamento(Pedido pedido)
        {
            //1 - Coloco o Cliente no Banco de Dados
            _pedidoRepository.Cadastrar(pedido);


            //Retorna o resultado
            //201 - Created
            return Created();
        }




        // Buscar Produto por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pedido pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(pedido);
        }


        // Deleta Produto por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Pedido não encontrado!");
            }
        }



        // Edita Produto por ID
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);
                return Ok(pedido);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }



    }
}
