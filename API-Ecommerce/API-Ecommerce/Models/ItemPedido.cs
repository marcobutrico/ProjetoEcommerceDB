using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Ecommerce.Models;

public partial class ItemPedido
{
    public int IdItem { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }

    [JsonIgnore]
     public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
