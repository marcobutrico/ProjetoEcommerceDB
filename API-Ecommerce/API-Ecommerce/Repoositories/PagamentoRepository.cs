using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Repoositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        // Metodos que acessam o banco de dados

        //Injetar o contexto Context 
        // Injecao de dependencia

        //salva o conteudo de Context
        private readonly EcommerceContext _context;



        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pagamento pagamento)
        {
            //Encontre o pagamento que desejo
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);
            //Caso nao encontrado, lanço um erro
            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.StatusPagamento = pagamento.StatusPagamento;
            pagamentoEncontrado.DataPagamento = pagamento.DataPagamento;
            pagamentoEncontrado.IdPedido = pagamento.IdPedido;

            _context.SaveChanges();
        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(c => c.IdPagamento == id);
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            //throw new NotImplementedException();
        }


        public void Deletar(int id)
        {
            //1. Encontrar o pagamento que quero excluir
            //Find. procura pela chave primaria
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);


            //Caso nao encontrado, lanço um erro
            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            //Salvo as alteracoes
            _context.SaveChanges();

        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.IdPedidoNavigation).ToList();
        }


    }
}
