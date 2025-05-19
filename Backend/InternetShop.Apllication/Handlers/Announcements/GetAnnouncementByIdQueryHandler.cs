using InternetShop.Domain.Interfaces;
using InternetShop.Domain.Entities;
using MediatR;
using InternetShop.Application.Queries.Announcements;
using System.Security.Cryptography;

namespace InternetShop.Application.Handlers.Announcements;

public class GetAnnouncementByIdQueryHandler(IAnnouncementRepository repository) : IRequestHandler<GetAnnouncementByIdQuery, Announcement>
{
    public async Task<Announcement> Handle(GetAnnouncementByIdQuery id, CancellationToken cancellationToken)
    {
        var announcement = await repository.GetByIdAsync(id.Id, cancellationToken);
        if(announcement is not null)
        {
            return announcement;
        }

        throw new NullReferenceException("Not found");
    } 
}
