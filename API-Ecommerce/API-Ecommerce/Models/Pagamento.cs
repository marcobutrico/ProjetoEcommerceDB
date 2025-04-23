using System;
using System.Collections.Generic;

namespace API_Ecommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public int IdPedido { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string StatusPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; } = null!;
}
