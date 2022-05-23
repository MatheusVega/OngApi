using AM.Amil.PeNaAreia.Domain.Dto;
using AM.Amil.PeNaAreia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Domain.Interfaces.Services
{
    public interface IProjetoService
    {
        Task<(bool sucesso, string mensagem, Projeto projeto)> Cadastrar(CadastroProjetoDto projetoDto);
        Task<(bool sucesso, string mensagem, DoacaoProjeto projeto)> CadastrarDoacao(CadastroDoacaoDto doacaoDto);
        Task<(bool sucesso, string mensagem, UsuarioProjeto projeto)> AdicionarUsuarioProjeto(AdicionarUsuarioProjetoDto usuarioProjetoDto);
    }
}
