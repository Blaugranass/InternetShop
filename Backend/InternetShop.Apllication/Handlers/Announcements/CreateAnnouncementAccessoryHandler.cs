using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;
using InternetShop.Domain.Enums;
using InternetShop.Application.Commands.Announcements;

namespace InternetShop.Application.Handlers.Announcements;

public class CreateAnnouncementAccessoryHandler(IAnnouncementRepository repository) : IRequestHandler<CreateAnnouncementAccessoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateAnnouncementAccessoryCommand command, CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Id = Guid.NewGuid(),
            Product = command.AccessoryDto.Accessory,
            Price = command.AccessoryDto.Price,
            Quantity = command.AccessoryDto.Quantity,
            CreatedAt = DateTime.UtcNow,
            Status = AnnouncementStatus.Active
        };

        await repository.CreateAsync(announcement, cancellationToken);

        return announcement.Id;
    }
}

