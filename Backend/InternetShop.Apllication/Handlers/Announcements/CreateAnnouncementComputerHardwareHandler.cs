using System;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Enums;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Announcements;

public class CreateAnnouncementComputerHardwareHandler(IAnnouncementRepository repository) : IRequestHandler<CreateAnnouncementComputerHardwareCommand, Guid>
{
    public async Task<Guid> Handle(CreateAnnouncementComputerHardwareCommand command, CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Id = Guid.NewGuid(),
            Product = command.HardwareDto.ComputerHardware,
            Price = command.HardwareDto.Price,
            Quantity = command.HardwareDto.Quantity,
            CreatedAt = DateTime.UtcNow,
            Status = AnnouncementStatus.Active
        };

        await repository.CreateAsync(announcement, cancellationToken);

        return announcement.Id;
    }
}