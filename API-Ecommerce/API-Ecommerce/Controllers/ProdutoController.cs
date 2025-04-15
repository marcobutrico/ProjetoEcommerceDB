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
  
        private IProdutoRepository _produtoRepository;
        
        //injecao de Dependência
        //Ao invés de EU instanciar a classe
        //Eu aviso que DEPENDO dela
        //E a responsbilidade de criar vem pra classe que chama (C#)
        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
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

            //Retorna o resultado
            //201 - Created
            return Created();
        }
    }
}
