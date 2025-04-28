namespace API_Ecommerce.DTO
{
    public class CadastrarPedidoDto
    {
        //Receber os dados do Pedido
        //E recebo os produtos comprados

        public int IdPedido { get; set; }

        public DateOnly DataPedido { get; set; }

        public string StatusPedido { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int? IdCliente { get; set; }

        //Produtos Comprados
        public List<int> Produtos { get; set; }
    }

}
