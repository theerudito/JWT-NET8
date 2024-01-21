using JWT_Models.Dtos;
using JWT_Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Backend.Helpers
{
    public class TokenManager
    {
        public static string GenerateToken(AuthDto authDto, IConfiguration config)
        {
            var jwtSection = config.GetSection("Jwt").Get<JwtManager>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection!.Token));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, authDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: jwtSection.Issuer,
                    audience: jwtSection.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials
                    );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}