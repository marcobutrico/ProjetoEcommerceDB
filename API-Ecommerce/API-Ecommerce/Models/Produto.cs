﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Ecommerce.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Imagem { get; set; }

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

}
