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
    public class PedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IClienteRepository _pedidoRepository;
        public PedidoController(EcommerceContext context)
        {
            _context = context;
            _pedidoRepository = new ClienteRepository(_context);
        }

        // GET
        [HttpGet]
        public IActionResult ListaPedido()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

    }
}
