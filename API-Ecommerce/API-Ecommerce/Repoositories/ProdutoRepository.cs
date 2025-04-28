using API_Ecommerce.Context;
using API_Ecommerce.DTO;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;
using API_Ecommerce.ViewModels;

namespace API_Ecommerce.Repoositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        // Metodos que acessam o banco de dados

        //Injetar o contexto Context 
        // Injecao de dependencia

        //salva o conteudo de Context
        private readonly EcommerceContext _context;

        //Carro carro1 = new Carro()

        //ctor - constructor
        //Metodo construtor
        // Quando criar um objeto, o que eu preciso ter


        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarProdutoDto produto)
        {
            //Encontre o produto que desejo
            Produto produtoEncontrado = _context.Produtos.Find(id);
            //Caso nao encontrado, lanço um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }
            produtoEncontrado.NomeProduto = produto.NomeProduto;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Estoque = produto.Estoque;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;

            _context.SaveChanges();


        }



        public void Cadastrar(CadastrarProdutoDto dtoproduto) // limitando a classe para os campos visualizaveis
        {
            Produto produtoCadastro = new Produto
            {
                NomeProduto = dtoproduto.NomeProduto,
                Descricao = dtoproduto.Descricao,
                Preco = dtoproduto.Preco,
                Estoque = dtoproduto.Estoque,
                Categoria = dtoproduto.Categoria,
                Imagem = dtoproduto.Imagem

            };
            _context.Produtos.Add(produtoCadastro);
            //2. Salvar a alteracao
            _context.SaveChanges();

        }

        public void CadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            //throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            //1. Encontrar o produto que quero excluir
            //Find. procura pela chave primaria
            Produto produtoEncontrado = _context.Produtos.Find(id);


            //Caso nao encontrado, lanço um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Produtos.Remove(produtoEncontrado);

            //Salvo as alteracoes
            _context.SaveChanges();

        }




        ListaProdutoViewModel IProdutoRepository.BuscarPorId(int id)
        {
             return _context.Produtos
            .Where(e => e.IdProduto == id)
            .Select(p => new ListaProdutoViewModel
            {
                IdProduto = p.IdProduto,
                NomeProduto = p.NomeProduto,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque,
                Categoria = p.Categoria,
                Imagem = p.Imagem
            }).FirstOrDefault();

        }


        List<ListaProdutoViewModel> IProdutoRepository.ListarTodos()
        {
            return _context.Produtos
            .Select(p => new ListaProdutoViewModel
            {
                IdProduto = p.IdProduto,
                NomeProduto = p.NomeProduto,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque,
                Categoria = p.Categoria,
                Imagem = p.Imagem
            }).ToList();
        }
    }
}
