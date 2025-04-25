using InternetShop.Domain.Entities;

namespace InternetShop.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(Admin admin);
}
