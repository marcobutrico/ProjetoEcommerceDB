using System;
using System.Collections.Generic;

namespace API_Ecommerce.Models;

public partial class ItemPedido
{
    public int IdItem { get; set; }

    public int? Quantidade { get; set; }

    public int? IdPedido { get; set; }

    public int? IdProduto { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
