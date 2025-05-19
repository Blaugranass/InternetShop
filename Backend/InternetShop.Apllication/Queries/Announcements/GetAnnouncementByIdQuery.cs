using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Queries.Announcements;

public record class GetAnnouncementByIdQuery(Guid Id) : IRequest<Announcement>;
