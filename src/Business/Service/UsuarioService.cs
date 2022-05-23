using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using AM.Amil.PeNaAreia.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Amil.PeNaAreia.Domain.Dto;
using AutoMapper;

namespace AM.Amil.PeNaAreia.Business.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(bool sucesso, string mensagem, Usuario usuario)> Cadastrar(CadastroUsuarioDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                usuario.DataAtualizacao = DateTime.Now;
                usuario.DataCadastro = DateTime.Now;
                usuario.Ativo = true;


               _unitOfWork.UsuarioRepository.Save(usuario);

                var salvo = await _unitOfWork.CommitAsync();

                if (salvo)
                    return (true, "Cadastro feito com sucesso", usuario);
                else
                    return (false, "Ocerreu uma erro ao salvar seu Usuario", usuario);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool sucesso, string mensagem, IEnumerable<Usuario> usuarios)> ListarTodos()
        {
            try
            {
                var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
                return (true, "Pesquisa feita com sucesso", usuarios);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool sucesso, string mensagem, Usuario usuarios)> BuscarCpf(string cpfCnpj)
        {
            try
            {
                var usuario = await _unitOfWork.UsuarioRepository.BuscarUsuario(cpfCnpj);
                return (true, "Pesquisa feita com sucesso", usuario);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool sucesso, string mensagem, Usuario usuarios)> Inativar(string cpfCnpj)
        {
            try
            {
                var usuario = await _unitOfWork.UsuarioRepository.BuscarUsuario(cpfCnpj);
                usuario.Ativo = false;
                usuario.DataAtualizacao = DateTime.Now;

                _unitOfWork.UsuarioRepository.Update(usuario);
                return (true, "Usuario inativado com sucesso", usuario);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
