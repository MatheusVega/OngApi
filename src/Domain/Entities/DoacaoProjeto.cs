using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Entities
{
    public class DoacaoProjeto : EntidadeBase
    {
        public Projeto Projeto { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
