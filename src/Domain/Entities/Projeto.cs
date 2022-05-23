using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Entities
{
    public class Projeto : EntidadeBase
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
