using InternetShop.Application.Pagination;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Filters;
using InternetShop.Domain.Interfaces;
using InternetShop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class AnnouncementRepository(ShopDbContext dbContext) : Repository<Announcement>(dbContext), IAnnouncementRepository
{

    private readonly ShopDbContext _dbContext = dbContext;

    public async Task<PagedResult<Announcement>> GetPagedAsync(PageParams pageParams, AnnouncementFilters filters, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Announcements
        .AsNoTracking()
        .Filter(filters)
        .ToPagedAsync(pageParams, cancellationToken); 
    }

    public async Task UpdateAsync(Announcement announcement, CancellationToken cancellationToken = default)
    {
        await _dbContext.Announcements
            .Where(a => a.Id == announcement.Id)
            .ExecuteUpdateAsync(set => set
            .SetProperty(a => a.Quantity, announcement.Quantity)
            .SetProperty(a => a.Product, announcement.Product)
            .SetProperty(a => a.Price, announcement.Price)
            .SetProperty(a => a.Status, announcement.Status),
            cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
