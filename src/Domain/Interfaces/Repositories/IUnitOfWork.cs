using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IProjetoRepository ProjetoRepository { get; }
        IUsuarioProjetoRepository UsuarioProjetoRepository { get; }
        IDoacaoProjetoRepository DoacaoProjetoRepository { get; }

        Task<bool> CommitAsync();

    }
}
