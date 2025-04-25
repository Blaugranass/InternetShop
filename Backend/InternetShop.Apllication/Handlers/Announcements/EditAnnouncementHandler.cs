using System;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Application.Dtos;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Announcements;

public class EditAnnouncementHandler(IAnnouncementRepository repository) : IRequestHandler<EditAnnouncementCommand>
{
    public async Task Handle(EditAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var announcement = new  Announcement
        {
            Id = command.Id,
            Status = command.AnnouncementDto.AnnouncementStatus,
            Quantity = command.AnnouncementDto.Quantity,
            Price = command.AnnouncementDto.Price
        };

        await repository.UpdateAsync(announcement, cancellationToken);
    }
}
