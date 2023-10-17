using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(ApplicationDbContext context,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var serviceResponse = new ServiceResponse<string>();

            var response = await
                _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            if (!response.Succeeded)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Usuário não encontrado.";
            }
            else
            {
                var user = _context.User
                .FirstOrDefault(u => u.Email!.ToLower().Equals(email.ToLower()));
                serviceResponse.Data = GenerateToken(user!);
            }

            serviceResponse.Message = "Autenticado com sucesso.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> Register(ApplicationUser user, string password)
        {
            var serviceResponse = new ServiceResponse<int>();

            var response = await _userManager.CreateAsync(user, password);

            if (!response.Succeeded)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = response.ToString();
                return serviceResponse;
            }

            serviceResponse.Message = "Novo usuário criado com sucesso.";
            return serviceResponse;
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var appToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appToken is null)
                throw new Exception("AppSettings Token não foi preenchida, favor verificar");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(appToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

