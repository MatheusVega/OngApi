using AM.Amil.PeNaAreia.Domain.Dto;
using AM.Amil.PeNaAreia.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProjetoController : Controller
    {
        private readonly IConfiguration _configuracao;
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService, IConfiguration configuration)
        {
            _configuracao = configuration;
            _projetoService = projetoService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cadatrar([FromBody] CadastroProjetoDto cadastroProjeto)
        {
            var (sucesso, mensagem, projeto) = await _projetoService.Cadastrar(cadastroProjeto);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = projeto,
                    Mensagem = mensagem
                });
            }
            else
                return BadRequest(mensagem);
        }
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarDoacao([FromBody] CadastroDoacaoDto doacaoDto)
        {
            var (sucesso, mensagem, doacao) = await _projetoService.CadastrarDoacao(doacaoDto);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = doacao,
                    Mensagem = mensagem
                });
            }
            else
                return BadRequest(mensagem);
        }
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarUsuarioProjeto([FromBody] AdicionarUsuarioProjetoDto usuarioProjetoDto)
        {
            var (sucesso, mensagem, usuarioProjeto) = await _projetoService.AdicionarUsuarioProjeto(usuarioProjetoDto);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = usuarioProjeto,
                    Mensagem = mensagem
                });
            }
            else
                return BadRequest(mensagem);
        }
    }
}
