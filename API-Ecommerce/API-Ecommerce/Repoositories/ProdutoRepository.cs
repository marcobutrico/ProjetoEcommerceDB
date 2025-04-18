﻿using API_Ecommerce.Context;
using API_Ecommerce.Interfaces;
using API_Ecommerce.Models;

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

        public void Atualizar(int id, Produto produto)
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

        public Produto BuscarPorId(int id)
        {

            return _context.Produtos.FirstOrDefault(e => e.IdProduto == id);
        }
            

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
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

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
