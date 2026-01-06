using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TockenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;

    public TockenService(IConfiguration config)
    {
        var tokenKey = config["TokenKey"];

        if (string.IsNullOrWhiteSpace(tokenKey))
        {
            throw new Exception("TokenKey configuration value is missing.");
        }

        if (tokenKey.Length < 32)
        {
            throw new Exception("TokenKey must be at least 32 characters long.");
        }

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    }

    public string CreateToken(appUser user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}