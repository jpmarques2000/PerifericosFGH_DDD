using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.DTO.AuthDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace WebAPIs.Controllers
{
    [Route("api/[User]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuthRepository authRepository, ILogger<UserController> logger)
        {
            _authRepository = authRepository;
            _logger = logger;
        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Email, Senha
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [AllowAnonymous]
        [HttpPost("/user/Login")]
        public async Task<ActionResult<ServiceResponse<int>>> LoginIdentity([FromBody] LoginDTO login)
        {
            _logger.LogInformation($"{DateTime.Now} | Realizando autenticação");
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return Unauthorized();
            }

            var response = await _authRepository.Login(login.Email, login.Password);

            if (!response.Success)
            {
                _logger.LogInformation($"{DateTime.Now} | Usuário ou senha invalídos");
                return Unauthorized();
            }
            _logger.LogInformation($"{DateTime.Now} | Autenticação realizada");
            return Ok(response);
        }

        /// <summary>
        /// Registrar novo usuário
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Email, senha, cpf e cep
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [AllowAnonymous]
        [HttpPost("/User/Register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterIdentity(UserRegisterDTO userData)
        {
            if (string.IsNullOrWhiteSpace(userData.Email) || string.IsNullOrWhiteSpace(userData.Password))
                return Ok("Dados imcompletos.");

            _logger.LogInformation($"{DateTime.Now} | Registrando novo usuário");
            var response = await _authRepository.Register(new ApplicationUser
            {
                UserName = userData.Email,
                Email = userData.Email,
                CPF = userData.CPF,
                EnderecoCEP = userData.CEP
            }, userData.Password!);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            _logger.LogInformation($"{DateTime.Now} | Registro do usuário {userData.Email} realizado");
            return Ok(response);

        }
    }
}
