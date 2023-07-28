using Microsoft.IdentityModel.Tokens;
using ReceitaWSAPI.Application.Models;
using ReceitaWSAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace webapi.Services
{
    public static class TokenService
    {
    
        public static string GenerateToken(LoginViewModel login)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string token = config["JwtSettings:Key"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(token);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Email),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)

            };

            var tokenToReturn = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(tokenToReturn);
        }
    }
}


