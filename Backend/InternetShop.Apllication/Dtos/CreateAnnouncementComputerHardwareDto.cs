using InternetShop.Domain.Entities;

namespace InternetShop.Application.Dtos;

public record class CreateAnnouncementComputerHardwareDto
(
    decimal Price,
    ComputerHardware ComputerHardware,
    int Quantity
);