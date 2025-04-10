﻿using API_Ecommerce.Models;

namespace API_Ecommerce.Interfaces
{
    public interface IProdutoRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar produtos - Read all
        List<Produto> ListarTodos();

        //CRUD
        //Listar produtos por Id - Read {id}
        //Recebe um Id e retorna o produto correspondente
        Produto BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Produto       produto (argumento)
        void Cadastrar(Produto produto);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o produto correspondente
        void Atualizar(int id, Produto produto);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o produto correspondente
        void Deletar(int id);
    }
}
