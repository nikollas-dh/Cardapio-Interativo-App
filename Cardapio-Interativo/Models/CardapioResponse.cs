using System;
using System.Collections.Generic;
using System.Text;

namespace Cardapio_Interativo.Models
{
    public class CardapioResponse
    {
        public int Id { get; set; }
        public string? Restaurante { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Valor { get; set; }
        public string? Foto { get; set; }
    }
}
