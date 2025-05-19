using System;
using InternetShop.Application.Commands.Clients;
using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InternetShop.Application.Handlers.Clients;

public class LoginClientHandler(IClientRepository repository, IJwtService jwtService) : IRequestHandler<LoginClientCommand>
{
    public async Task Handle(LoginClientCommand command, CancellationToken cancellationToken)
    {
        var client = await repository.GetByMailAsync(command.Client.Mail, cancellationToken);

        var result = new PasswordHasher<Client>()
            .VerifyHashedPassword(client, client.HashPassword, command.Client.Password);

        if(result == PasswordVerificationResult.Success)
        {
            jwtService.GenerateToken(client);
        }
        else
        {
            throw new Exception("Wrong Password or Name");
        }
    }
    
}
