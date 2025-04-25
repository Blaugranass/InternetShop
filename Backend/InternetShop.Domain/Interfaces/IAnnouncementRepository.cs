using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface IAnnouncementRepository : IRepository<Announcement>
{
    Task UpdateAsync(Announcement announcement, CancellationToken cancellationToken = default);

}