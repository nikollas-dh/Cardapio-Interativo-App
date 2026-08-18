using System;
using System.Collections.Generic;
using System.Text;

namespace Cardapio_Interativo.Models
{
    public class PratoRanking
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public int Curtidas { get; set; }
    }
}
