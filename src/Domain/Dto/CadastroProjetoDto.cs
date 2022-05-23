using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Dto
{
    public class CadastroDoacaoDto
    {
        public int IdProjeto { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
