using AM.Amil.PeNaAreia.Domain.Dto;
using AM.Amil.PeNaAreia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<(bool sucesso, string mensagem, Usuario usuario)> Cadastrar(CadastroUsuarioDto usuarioDto);
        Task<(bool sucesso, string mensagem, IEnumerable<Usuario> usuarios)> ListarTodos();
        Task<(bool sucesso, string mensagem, Usuario usuarios)> BuscarCpf(string cpfCnpj);
        Task<(bool sucesso, string mensagem, Usuario usuarios)> Inativar(string cpfCnpj);
    }
}
