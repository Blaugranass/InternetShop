using InternetShop.Domain.Entities;

namespace InternetShop.Application.Dtos.Announcements;

public record class CreateAnnouncementComputerHardwareDto
(
    decimal Price,
    ComputerHardware ComputerHardware,
    int Quantity
);