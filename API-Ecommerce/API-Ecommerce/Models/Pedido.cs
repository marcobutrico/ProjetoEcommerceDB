﻿using System;
using System.Collections.Generic;

namespace API_Ecommerce.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateOnly? DataPedido { get; set; }

    public string? StatusPedido { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
