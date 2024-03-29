using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NinoBank.Application.Models.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NinoBank.Application.Services
{
    public class TokenService
    {
        private readonly IOptions<JWTConfiguration> _options;

        public TokenService(IOptions<JWTConfiguration> options)
        {
            _options = options;
        }

        public string GenerateJwtToken(Guid userId)
        {
            var stringId = userId.ToString();
            var tokenHandler = new JwtSecurityTokenHandler();


            var key = Convert.FromBase64String(_options.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                     new Claim(ClaimTypes.NameIdentifier, stringId)
                }),

                Expires = DateTime.UtcNow.AddMinutes(_options.Value.ExpirationInMinutes), 

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
