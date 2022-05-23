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
    public class UsuarioController : Controller
    {
        private readonly IConfiguration _configuracao;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _configuracao = configuration;
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cadatrar([FromBody] CadastroUsuarioDto cadastroUsuario)
        {
            var (sucesso, mensagem, usuario) = await _usuarioService.Cadastrar(cadastroUsuario);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = usuario,
                    Mensagem = mensagem
                });
            }
            else
                return BadRequest(mensagem);
        }

        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodos()
        {
            var (sucesso, mensagem, usuarios) = await _usuarioService.ListarTodos();
            if (sucesso)
            {
                return Ok(new
                {
                    Data = usuarios,
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
        public async Task<IActionResult> BuscarCpf([FromBody] string cpfCnpj)
        {
            var (sucesso, mensagem, usuarios) = await _usuarioService.BuscarCpf(cpfCnpj);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = usuarios,
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
        public async Task<IActionResult> Inativar([FromBody] string cpfCnpj)
        {
            var (sucesso, mensagem, usuarios) = await _usuarioService.Inativar(cpfCnpj);
            if (sucesso)
            {
                return Ok(new
                {
                    Data = usuarios,
                    Mensagem = mensagem
                });
            }
            else
            {
                return BadRequest(mensagem);
            }
        }
    }
}
