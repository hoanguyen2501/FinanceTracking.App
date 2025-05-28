using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinanceTracking.Identity.Entities;
using FinanceTracking.Identity.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinanceTracking.Identity.Services.Implementations
{
    public sealed class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IServiceProvider provider)
        {
            _jwtSettings = provider.GetRequiredService<IOptions<JwtSettings>>().Value ?? throw new Exception("JwtSettings are not configured properly.");
        }
        public string GenerateToken(User user)
        {
            var email = user.Email ?? throw new Exception("User email cannot be null.");
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}