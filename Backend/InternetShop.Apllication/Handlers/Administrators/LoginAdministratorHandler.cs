using System;
using InternetShop.Application.Commands.Administrators;
using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InternetShop.Application.Handlers.Administrators;

public class LoginAdministratorHandler(IAdminRepository repository, IJwtService jwtService) : IRequestHandler<LoginAdministratorCommand>
{
    public async Task Handle(LoginAdministratorCommand command, CancellationToken cancellationToken)
    {
        var admin = await repository.GetByNameAsync(command.LoginAdmin.Name);
        if(admin is null)
        {
            throw new Exception("Admin with this name not found");
        }

        var result = new PasswordHasher<Admin>()
            .VerifyHashedPassword(admin, admin.HashPassword, command.LoginAdmin.Password);

        if(result == PasswordVerificationResult.Success)
        {
            jwtService.GenerateToken(admin);
        }
        else
        {
            throw new Exception("Wrong Password or Name");
        }
    }
}
