using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Coink.Cross.Security.Token;
using Coink.Application.Interfaces.Services;

namespace Coink.Infrastructure.Services.Security;

public class TokenService(IOptions<JwtCredentials> setting) : ITokenService
{
    private readonly JwtCredentials _setting = setting.Value;
    public string JwtToken()
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_setting.Secret));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _setting.Issuer,
            audience: _setting.Audience,
            expires: DateTime.Now.AddMinutes(_setting.ExpirationTime),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}