
using InternetShop.Application.Pagination;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Filters;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Extensions;

public static class AnnouncementExtensions
{
    public static IQueryable<Announcement> Filter(this IQueryable<Announcement> query, AnnouncementFilters filter)
    {
        if (filter.LowerThan is not null)
            query = query.Where(a => a.Price <= filter.LowerThan);

        if(filter.HigherThen is not null)
            query = query.Where(a => a.Price >= filter.HigherThen);
            
        return query; 
    }

    public static async Task<PagedResult<Announcement>> ToPagedAsync(
        this IQueryable<Announcement> query,
        PageParams pageParams,
        CancellationToken cancellationToken = default)
    {
        var count = await query.CountAsync(cancellationToken);
            if(count == 0)
                return new PagedResult<Announcement>([] ,0);

        var page = pageParams.Page ?? 1;
        var pageSize = pageParams.PageSize ?? 10;

        var skip = (page - 1) * pageSize;
        var result = await query.Skip(skip)
                                    .Take(pageSize)
                                    .ToArrayAsync(cancellationToken);

        return new PagedResult<Announcement>(result, count);
    }
}
