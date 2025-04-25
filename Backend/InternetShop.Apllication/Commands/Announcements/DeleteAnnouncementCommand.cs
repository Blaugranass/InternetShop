using MediatR;

namespace InternetShop.Application.Commands.Announcements;

public record class DeleteAnnouncementCommand(Guid Id) : IRequest;