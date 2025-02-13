using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Interfaces.JWT;
using ECommerce.Core.Entities.User;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.App.Services.JWT
{
    public class JwtService : IJwtService
    {
        private readonly ICookiesService _cookiesService;

        public JwtService(ICookiesService cookiesService)
        {
            _cookiesService = cookiesService;
        }

        public string GenerateToken(UserEf user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // подключаем библиотеку System.IdentityModel.Tokens.Jwt
            var keyHashing = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"]); // получаем ключ из конфига по которому будем шифровать

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // добавляем в токен данные о пользователе
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("Email", user.Email), 
                    new Claim("RoleId", user.UserType.ToString()), 
                }),
                
                Expires = DateTime.UtcNow.AddHours(1), 
                
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyHashing),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // получаем токен
            return tokenHandler.WriteToken(token); // преобразуем токен в удобную строку 

        }

        public int GetUserIdFromToken(string token)
        {
            throw new NotImplementedException();

        }

        public int GetUserRoleIdFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public string GetUserEmailFromToken(string token)
        {
            throw new NotImplementedException();
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
             => await IsTokenValid(await _cookiesService.GetCookie("jwt"));
    }
}