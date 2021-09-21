using DbProvider.Abstractions;
using DbProvider.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DbProvider.Implementations
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;
        private readonly int _expDate;

        public JWTService(IOptions<JWTConfiguration> option)
        {
            _secret = option.Value.Secret;
            _expDate = option.Value.ExpirationInMinutes;
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name,"Beqa")
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expDate),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
