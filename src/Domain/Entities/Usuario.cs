using AM.Amil.PeNaAreia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
