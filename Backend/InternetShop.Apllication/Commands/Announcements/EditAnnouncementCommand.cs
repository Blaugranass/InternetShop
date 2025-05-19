using InternetShop.Application.Dtos.Announcements;
using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Commands.Announcements;

public record class EditAnnouncementCommand(
    Guid Id, EditAnnouncementDto AnnouncementDto) : IRequest;