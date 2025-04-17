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


        // Cadastrar Pagamento
        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            //1 - Coloco o Cliente no Banco de Dados
            _pagamentoRepository.Cadastrar(pagamento);


            //Retorna o resultado
            //201 - Created
            return Created();
        }

        // Buscar Produto por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Pagamento pagamento = _pagamentoRepository.BuscarPorId(id);

            if (pagamento == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(pagamento);
        }


        // Deleta Produto por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pagamentoRepository.Deletar(id);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Pagamento não encontrado!");
            }
        }



        // Edita Produto por ID
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pagamento pagto)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pagto);
                return Ok(pagto);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }



    }
}
