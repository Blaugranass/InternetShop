using InternetShop.Application.Dtos;
using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Commands.Announcements;

public record class EditAnnouncementCommand(Guid Id, EditAnnouncementDto AnnouncementDto) : IRequest;