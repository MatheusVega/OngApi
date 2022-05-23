
using System.Threading.Tasks;
using AM.Amil.PeNaAreia.Domain.Dto;

namespace AM.Amil.PeNaAreia.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<(LoginDto loginDto, bool autenticado, string mensagem)> AutenticarUsuario(LoginDto autenticacaoDto);

    }
}
