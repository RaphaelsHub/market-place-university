using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Interfaces.JWT;
using ECommerce.Core.Models.DTOs.User;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.App.Services.JWT
{
    public class JwtService : IJwtService
    {
        private readonly ICookiesService _cookiesService;

        public JwtService(ICookiesService cookiesService) =>
            _cookiesService = cookiesService;

        public async Task<string> GenerateToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // подключаем библиотеку System.IdentityModel.Tokens.Jwt
            var keyHashing = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"]); // получаем ключ из конфига по которому будем шифровать

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // добавляем в токен данные о пользователе
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email), 
                    new Claim("RoleId", user.UserType.ToString()), 
                }),
                
                Expires = DateTime.UtcNow.AddHours(1), 
                
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyHashing),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // получаем токен
            return  tokenHandler.WriteToken(token); // преобразуем токен в удобную строку 
        }

        public async Task<int> GetUserIdFromToken()
        {
            var token = _cookiesService.GetCookie("jwt");

            if (string.IsNullOrEmpty(token))
                return 0;

            var idClaim = GetClaim("Id", token);

            return idClaim == null ? 0 : int.Parse(idClaim.Value);
        }

        public async Task<int> GetUserRoleIdFromToken()
        {
            var token = _cookiesService.GetCookie("jwt");

            if (string.IsNullOrEmpty(token))
                return 0;

            var roleClaim = GetClaim("RoleId", token);

            return roleClaim == null ? 0 : int.Parse(roleClaim.Value);
        }

        public async Task<string> GetUserEmailFromToken()
        {
            var token = _cookiesService.GetCookie("jwt");

            if (string.IsNullOrEmpty(token))
                return "";

            var emailClaim = GetClaim("Email", token);

            return emailClaim == null ? "" : emailClaim.Value;
        }
        
        public Task<bool> IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
                return Task.FromResult(false);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyHashing = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyHashing),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var expiration = jwtToken.ValidTo;

                return Task.FromResult(expiration > DateTime.UtcNow);
            }
            catch
            {
                return Task.FromResult(true);
            }
        }
        
        public async Task<bool> IsTokenValid() 
             => await IsTokenValid(_cookiesService.GetCookie("jwt"));
        
        private Claim GetClaim(string claimType, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.Claims.FirstOrDefault(claim => claim.Type == claimType);
        }
    }
}