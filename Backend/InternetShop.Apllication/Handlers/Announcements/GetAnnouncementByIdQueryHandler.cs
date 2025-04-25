using InternetShop.Domain.Interfaces;
using InternetShop.Domain.Entities;
using MediatR;
using InternetShop.Application.Quaries;

namespace InternetShop.Application.Handlers.Announcements;

public class GetAnnouncementByIdQueryHandler(IAnnouncementRepository repository) : IRequestHandler<GetAnnouncementByIdQuery, Announcement>
{
    public async Task<Announcement> Handle(GetAnnouncementByIdQuery id, CancellationToken cancellationToken)
    {
        var announcement = await repository.GetByIdAsync(id.Id);
        if(announcement is not null)
        {
            return announcement;
        }

        throw new NullReferenceException("Not found");
    } 
}
