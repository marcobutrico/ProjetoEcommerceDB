using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;

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
            throw new NotImplementedException();
        }

         public Pagamento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            //throw new NotImplementedException();
        }


        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.ToList();
            //throw new NotImplementedException();
        }

 
    }
}
