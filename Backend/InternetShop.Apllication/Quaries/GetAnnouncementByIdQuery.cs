using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Quaries;

public record class GetAnnouncementByIdQuery(Guid Id) : IRequest<Announcement>;
