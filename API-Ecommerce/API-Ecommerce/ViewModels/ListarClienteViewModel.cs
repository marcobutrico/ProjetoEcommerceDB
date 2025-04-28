using API_Ecommerce.Models;

namespace API_Ecommerce.ViewModels
{
    public class ListarClienteViewModel
    {
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public DateOnly DataCadastro { get; set; }

    }
}
