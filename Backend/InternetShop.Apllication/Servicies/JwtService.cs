using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InternetShop.Application.Interfaces;
using InternetShop.Application.Settings;
using InternetShop.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InternetShop.Application.Servicies;

public class JwtService(IOptions<AuthSettings> options) : IJwtService
{
    public string GenerateToken(Admin admin)
    {
        var claims = new List<Claim>
        {
            new ("Role", "Admin"),
            new ("Id", admin.Id.ToString())
        };
        
        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.Expires),
            claims : claims,
            signingCredentials :
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
        
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
