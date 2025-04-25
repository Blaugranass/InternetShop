using InternetShop.Application.Commands.Administrators;
using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InternetShop.Application.Handlers.Administrators;

public class RegisterAdministratorHandler(IAdminRepository repository, IJwtService jwtService) : IRequestHandler<RegisterAdministratorCommand>
{
    public async Task Handle(RegisterAdministratorCommand command, CancellationToken cancellationToken)
    {
        var admin = new Admin()
        {
            Id = Guid.NewGuid(),
            Name = command.RegisterAdmin.Name
        };

        var passHash = new PasswordHasher<Admin>().HashPassword(admin, command.RegisterAdmin.Password);
        admin.HashPassword = passHash;
        
        await repository.CreateAsync(admin, cancellationToken);

        jwtService.GenerateToken(admin);
    }
}