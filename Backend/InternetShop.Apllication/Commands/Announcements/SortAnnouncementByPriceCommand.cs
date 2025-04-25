using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Commands.Announcements;

public record class SortAnnouncementByPriceCommand(decimal Price) : IRequest<IEnumerable<Announcement>>; 