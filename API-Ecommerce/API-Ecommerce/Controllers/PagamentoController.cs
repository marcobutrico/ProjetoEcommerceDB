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
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IPagamentoRepository _pagamentoRepository;
        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new PagamentoRepository(_context);
        }

        // 1 - Definir o verbo: GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }


        // Cadastrar Produtos
        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            //1 - Coloco o Cliente no Banco de Dados
            _pagamentoRepository.Cadastrar(pagamento);


            //Retorna o resultado
            //201 - Created
            return Created();
        }
    }
}