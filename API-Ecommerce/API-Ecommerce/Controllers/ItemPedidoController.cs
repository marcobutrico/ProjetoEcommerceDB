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
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IItemPedidoRepository _itempedidoRepository;

       
        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itempedidoRepository = new ItemPedidoRepository(_context);
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_itempedidoRepository.ListarTodos());
        }

        // Cadastrar Itens dos Pedidos
        [HttpPost]
        public IActionResult CadadstrarItemPedido(ItemPedido itempedido)
        {
            //1 - Coloco o Cliente no Banco de Dados
            _itempedidoRepository.Cadastrar(itempedido);


            //Retorna o resultado
            //201 - Created
            return Created();
        }




        // Buscar Item do Pedido por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            ItemPedido itempedido = _itempedidoRepository.BuscarPorId(id);

            if (itempedido == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(itempedido);
        }


        // Deleta Pedido por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _itempedidoRepository.Deletar(id);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Item do Pedido não encontrado!");
            }
        }



        // Edita Item do Pedido por ID
        [HttpPut("{id}")]
        public IActionResult Editar(int id, ItemPedido itempedido)
        {
            try
            {
                _itempedidoRepository.Atualizar(id, itempedido);
                return Ok(itempedido);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }



    }
}
