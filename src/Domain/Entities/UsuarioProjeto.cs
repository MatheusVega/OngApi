using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Entities
{
    public class UsuarioProjeto : EntidadeBase
    {
        public Usuario Usuario { get; set; }
        public Projeto Projeto { get; set; }
    }
}
