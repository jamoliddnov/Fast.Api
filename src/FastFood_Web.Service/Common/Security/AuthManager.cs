using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastFood_Web.Service.Common.Security
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration configuration;

        public AuthManager(IConfiguration configuration)
        {
            this.configuration = configuration.GetSection("Jwt");
        }

        public string GenerateToken(User user)
        {
            var claims = new[] {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDeskriptor = new JwtSecurityToken(configuration["Issuer"], configuration["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(configuration["Lifetime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDeskriptor);
        }
    }
}
