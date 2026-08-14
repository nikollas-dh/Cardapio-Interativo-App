using System;
using System.Collections.Generic;

namespace Cardapio_Interativo.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Prato> Pratos { get; set; } = new List<Prato>();
}
