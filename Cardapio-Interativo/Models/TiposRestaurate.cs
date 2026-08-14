using System;
using System.Collections.Generic;

namespace Cardapio_Interativo.Models;

public partial class TiposRestaurate
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Icone { get; set; }

    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
