using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
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

    }
}
