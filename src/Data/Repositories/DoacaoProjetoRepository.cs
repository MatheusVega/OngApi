using AM.Amil.PeNaAreia.Data.Context;
using AM.Amil.PeNaAreia.Data.Repositories;
using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Data.Repositories
{
    public class DoacaoProjetoRepository : BaseRepository<DoacaoProjeto>, IDoacaoProjetoRepository
    {
        public DoacaoProjetoRepository(PhmContext context) : base(context)
        {
        }
    }
}
