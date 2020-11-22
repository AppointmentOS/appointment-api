using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Bookeasy.Domain.Entities;
using MongoDB.Bson;

namespace Bookeasy.Infrastructure.Identity
{
    public interface IAuthenticationTokenGenerator
    {
        string GenerateToken(List<Claim> claimsInfo);
        RefreshToken GenerateRefreshToken(string userId, string ipAddress);
    }

    public class JwtAuthenticationTokenGenerator : IAuthenticationTokenGenerator
    {
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;

        public JwtAuthenticationTokenGenerator(string jwtKey, string jwtIssuer)
        {
            _jwtKey = jwtKey;
            _jwtIssuer = jwtIssuer;
        }

        public string GenerateToken(List<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtIssuer,
                _jwtIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(string userId, string ipAddress)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Id = ObjectId.GenerateNewId(),
                UserId = userId,
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedByIp = ipAddress
            };
        }
    }
}
