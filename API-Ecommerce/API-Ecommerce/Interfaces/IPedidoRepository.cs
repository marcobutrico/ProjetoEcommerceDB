﻿using API_Ecommerce.DTO;
using API_Ecommerce.Models;

namespace API_Ecommerce.Interfaces
{
    public interface IPedidoRepository
    {
        //Fachada - Contrato 
        //CRUD
        //Listar pedidos - Read all
        List<Pedido> ListarTodos();

        //CRUD
        //Listar pedidos por Id - Read {id}
        //Recebe um Id e retorna o pedido correspondente
        Pedido BuscarPorId(int id);


        //CRUD
        //C - Create (cadastro)
        //Pedido       pedido (argumento)
        void Cadastrar(CadastrarPedidoDto pedido);

        //CRUD
        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada o pedido correspondente
        void Atualizar(int id, Pedido pedido);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta o pedido correspondente
        void Deletar(int id);
    }
}
