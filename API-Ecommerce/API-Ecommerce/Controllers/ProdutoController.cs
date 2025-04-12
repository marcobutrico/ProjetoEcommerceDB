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
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IProdutoRepository _produtoRepository;
        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(_context);
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }


        // Cadastrar Produtos
        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            //1 - Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(produto);

            //2. Salvar a alteracao
            _context.SaveChanges();

            //Retorna o resultado
            //201 - Created
            return Created();
        }
    }
}
