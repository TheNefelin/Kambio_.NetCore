﻿using ClassLibraryModels.DTOs.Auth;
using ClassLibraryServer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClassLibraryServer.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public TokenDTO GenerateJwtToken(LogedinDTO logedin, JwtConfigDTO jwtConfig)
        {
            // Define los claims (información contenida en el token)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, logedin.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, logedin.Email),
                new Claim(ClaimTypes.Role, logedin.Role)
            };

            // Genera una clave simétrica a partir del secret en appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Configuración del token: audiencia, emisor, expiración y firma
            var token = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.ExpireMin)),
                signingCredentials: creds
            );

            return new TokenDTO {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
