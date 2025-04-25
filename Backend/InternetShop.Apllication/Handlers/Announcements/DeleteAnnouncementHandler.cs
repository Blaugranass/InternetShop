using System;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Announcements;

public class DeleteAnnouncementHandler(IAnnouncementRepository repository) : IRequestHandler<DeleteAnnouncementCommand>
{
    public async Task Handle(DeleteAnnouncementCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(command.Id, cancellationToken);
    }
}
