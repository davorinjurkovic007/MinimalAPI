using DevNot21.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevNot21.Service
{
    public class TokenService : ITokenService
    {
        private readonly WebApplicationBuilder builder;

        public TokenService(WebApplicationBuilder builder)
        {
            this.builder = builder;
        }

        public string GetToken(DbUser user)
        {
            var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };
            var token = new JwtSecurityToken
            (
                issuer: builder.Configuration["Issuer"],
                audience: builder.Configuration["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"])), SecurityAlgorithms.HmacSha256)
            ); return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
