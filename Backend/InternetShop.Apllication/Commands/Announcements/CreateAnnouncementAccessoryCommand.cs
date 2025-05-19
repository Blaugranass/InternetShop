using InternetShop.Application.Dtos.Announcements;
using MediatR;

namespace InternetShop.Application.Commands.Announcements;

public record class CreateAnnouncementAccessoryCommand(
    CreateAnnouncementAccessoryDto AccessoryDto) : IRequest<Guid>;