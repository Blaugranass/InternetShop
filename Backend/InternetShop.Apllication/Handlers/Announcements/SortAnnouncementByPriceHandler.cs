using System;
using InternetShop.Application.Commands.Announcements;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Announcements;

public class SortAnnouncementByPriceHandler(IAnnouncementRepository repository) : IRequestHandler<SortAnnouncementByPriceCommand, IEnumerable<Announcement>>
{
    public async Task<IEnumerable<Announcement>> Handle(SortAnnouncementByPriceCommand command, CancellationToken cancellationToken)
    {
        return await repository.GetByFilterAsync(a=> a.Price == command.Price, cancellationToken);
    }
}
