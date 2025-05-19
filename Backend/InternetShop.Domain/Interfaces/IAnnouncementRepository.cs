using InternetShop.Application.Pagination;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Filters;

namespace InternetShop.Domain.Interfaces;

public interface IAnnouncementRepository : IRepository<Announcement>
{
    Task UpdateAsync(Announcement announcement, CancellationToken cancellationToken = default);

    Task<PagedResult<Announcement>> GetPagedAsync(PageParams pageParams, AnnouncementFilters filters, CancellationToken cancellationToken = default);

}