using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Threading.Tasks;
using AM.Amil.PeNaAreia.Domain.Interfaces.Services;
using AM.Amil.PeNaAreia.Domain.Dto;
using AM.Amil.PeNaAreia.Business.Service;
using System;
using AM.Amil.PeNaAreia.Api.Extensions;

namespace AM.Amil.PeNaAreia.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class AuthenticationController : MainController
    {
        private readonly IConfiguration _configuracao;
        private readonly ILogger _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IConfiguration configuracao,
            ILogger logger,
            IAuthenticationService authenticationService)
        {
            _configuracao = configuracao;
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Autenticar([FromBody] LoginDto loginDto)
        {
            try
            {
                var (authDto, autenticado, mensagem) = await _authenticationService.AutenticarUsuario(loginDto);

                if (!autenticado)
                {
                    _logger.Warn("Login - Não Autenticado: ", mensagem);
                    return BadRequest(mensagem);
                }

                _logger.Info("Login - Usuario Logado: " + mensagem + "Id: " + authDto.Id);

                return Ok(new
                {
                    messagem = mensagem,
                    token = TokenService.GerarTokenJwt(authDto, _configuracao)
                });
            }
            catch (Exception exception)
            {
                _logger.Fatal("Auth - Exception: " + exception.ToLogString(Environment.StackTrace));
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        exception = exception.Message,
                        innerException = exception.InnerException != null ? exception.InnerException.Message : ""
                    });
            }
        }

    }
}
