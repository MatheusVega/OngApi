using AM.Amil.PeNaAreia.Domain.Dto;
using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using AM.Amil.PeNaAreia.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Business.Service
{
    public class ProjetoService : IProjetoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjetoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<(bool sucesso, string mensagem, Projeto projeto)> Cadastrar(CadastroProjetoDto projetoDto)
        {
            try
            {
                var projeto = _mapper.Map<Projeto>(projetoDto);
                projeto.DataCadastro = DateTime.Now;
                projeto.Ativo = true;


                _unitOfWork.ProjetoRepository.Save(projeto);

                var salvo = await _unitOfWork.CommitAsync();

                if (salvo)
                    return (true, "Cadastro feito com sucesso", projeto);
                else
                    return (false, "Ocorreu um erro ao salvar seu projeto", projeto);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool sucesso, string mensagem, DoacaoProjeto projeto)> CadastrarDoacao(CadastroDoacaoDto doacaoDto)
        {
            try
            {
                var doacao = new DoacaoProjeto();
                doacao.Projeto = await _unitOfWork.ProjetoRepository.GetById(doacaoDto.IdProjeto);
                doacao.Valor = doacaoDto.Valor;
                doacao.Descricao = doacaoDto.Descricao;


                _unitOfWork.DoacaoProjetoRepository.Save(doacao);

                var salvo = await _unitOfWork.CommitAsync();

                if (salvo)
                    return (true, "Cadastro feito com sucesso", doacao);
                else
                    return (false, "Ocorreu um erro ao salvar seu projeto", doacao);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool sucesso, string mensagem, UsuarioProjeto projeto)> AdicionarUsuarioProjeto(AdicionarUsuarioProjetoDto usuarioProjetoDto)
        {
            try
            {
                var usuarioProjeto = new UsuarioProjeto();
                usuarioProjeto.Projeto = await _unitOfWork.ProjetoRepository.GetById(usuarioProjetoDto.IdProjeto);
                usuarioProjeto.Usuario = await _unitOfWork.UsuarioRepository.GetById(usuarioProjetoDto.IdUsuario);


                _unitOfWork.UsuarioProjetoRepository.Save(usuarioProjeto);

                var salvo = await _unitOfWork.CommitAsync();

                if (salvo)
                    return (true, "Cadastro feito com sucesso", usuarioProjeto);
                else
                    return (false, "Ocorreu um erro ao salvar seu projeto", usuarioProjeto);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
