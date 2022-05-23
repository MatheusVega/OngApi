using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Amil.PeNaAreia.Domain.Entities
{
    public class EntidadeBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
