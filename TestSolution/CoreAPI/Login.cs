using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public static class Login
    {
        public static TokenResponseDTO GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the best secret key the api ever have @#@#@#"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("ClientType", "ClientZZZZ")
            };

            DateTime expireDate = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                claims: claims,
                notBefore: DateTime.Now,
                expires: expireDate,
                signingCredentials: credentials
            );

            return new TokenResponseDTO
            {
                UserId = user.UserId.ToString(),
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresDate = expireDate
            };
        }
    }
}
