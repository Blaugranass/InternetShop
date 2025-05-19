using InternetShop.Application.Dtos.Announcements;
using MediatR;

namespace InternetShop.Application.Queries.Announcements;

public record class GetActiveAnnouncementsQuery() : IRequest<IEnumerable<AnnouncementUserDto>>;