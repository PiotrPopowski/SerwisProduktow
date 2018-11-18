using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Extensions;
using SerwisProduktow.Infrastructure.Models;

namespace SerwisProduktow.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings jwtSettings;
        public JwtHandler()
        {
            jwtSettings = new JwtSettings
            {
                Key = ConfigurationManager.AppSettings["SecretKey"],
                ExpiryMinutes = int.Parse(ConfigurationManager.AppSettings["TokenExpiryMinutes"]),
                Issuer = ConfigurationManager.AppSettings["Issuer"]
            };
        }
        public JwtDto CreateToken(int userID, string role)
        {
            var symmetricKey = Convert.FromBase64String(jwtSettings.Key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, userID.ToString()),
                            new Claim(ClaimTypes.Role, role)
                        }),
                Issuer = jwtSettings.Issuer,
                Expires = now.AddMinutes(Convert.ToInt32(jwtSettings.ExpiryMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return new JwtDto
            {
                Token = token,
                Expires = tokenDescriptor.Expires.Value.ToTimestamp()
            };
        }
    }
}
