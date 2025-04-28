using API_Ecommerce.Models;

namespace API_Ecommerce.ViewModels
{
    public class ListaProdutoViewModel
    {
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Imagem { get; set; }

    }

}
