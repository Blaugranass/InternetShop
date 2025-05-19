using System;
using InternetShop.Application.Pagination;
using InternetShop.Application.Queries.Announcements;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Announcements;

public class GetAnnouncementsHandler(IAnnouncementRepository announcementRepository) : IRequestHandler<GetAnnouncementsQuery, PagedResult<Announcement>>
{
    public async Task<PagedResult<Announcement>> Handle(GetAnnouncementsQuery query, CancellationToken cancellationToken)
    {
        var result = await announcementRepository.GetPagedAsync
            (query.PageParams, query.AnnouncementFilters, cancellationToken)
                ?? throw new NullReferenceException("Not found announcements");

        return result;

    }
}