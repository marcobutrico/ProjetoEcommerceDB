using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using API_Ecommerce.Repoositories;
using API_Ecommerce.ViewModels;
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
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        // Buscar Produto por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            ListaProdutoViewModel produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(produto);
        }





        // Cadastrar Produtos
        [HttpPost]
        public IActionResult CadastrarProduto(CadastrarProdutoDto dtoproduto)
        {
            //1 - Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(dtoproduto);

            //Retorna o resultado
            //201 - Created
            return Created();
        }


        // Edita Produto por ID
        [HttpPut("{id}")]
        public IActionResult Editar(int id, CadastrarProdutoDto dtoprod)
        {
            try
            {
                _produtoRepository.Atualizar(id, dtoprod);
                return Ok(dtoprod);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }






        // Deleta Produto por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Produto não encontrado!");
            }
        }

        
    }
}
