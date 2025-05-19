using InternetShop.Application.Dtos.Announcements;
using InternetShop.Application.Pagination;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Filters;
using MediatR;

namespace InternetShop.Application.Queries.Announcements;

public record GetAnnouncementsQuery(
    PageParams PageParams,
    AnnouncementFilters AnnouncementFilters ) : IRequest<PagedResult<Announcement>>;
