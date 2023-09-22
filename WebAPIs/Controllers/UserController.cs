using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.DTO;
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

        public UserController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("/user/Login")]
        public async Task<ActionResult<ServiceResponse<int>>> LoginIdentity([FromBody] LoginDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return Unauthorized();
            }

            var response = await _authRepository.Login(login.Email, login.Password);

            if (!response.Success)
            {
                return Unauthorized();
            }
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("/User/Register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterIdentity(UserRegisterDTO userData)
        {
            if (string.IsNullOrWhiteSpace(userData.Email) || string.IsNullOrWhiteSpace(userData.Password))
                return Ok("Dados imcompletos.");

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
            return Ok(response);

        }
    }
}
