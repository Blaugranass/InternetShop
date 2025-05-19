using System;
using InternetShop.Application.Commands.Clients;
using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Clients;

public class RegisterClientHandler(IClientRepository repository, IJwtService jwtService) : IRequestHandler<RegisterClientCommand> 
{
    public async Task Handle(RegisterClientCommand command, CancellationToken cancellationToken)
    {
        if(await repository.ExistWithMail(command.ClientDto.Mail, cancellationToken))
        {
            throw new Exception("User with this mail already exists");
        }
        if(await repository.ExistsWithNumber(command.ClientDto.PhoneNumber, cancellationToken))
        {
            throw new Exception("User with this phone number already exists");
        }

        var client = new Client
        {
            Id = Guid.NewGuid(),
            Mail = command.ClientDto.Mail,
            PhoneNumber = command.ClientDto.PhoneNumber,
            Favorites = []
        };

        await repository.CreateAsync(client, cancellationToken);

        jwtService.GenerateToken(client);
    }
}
