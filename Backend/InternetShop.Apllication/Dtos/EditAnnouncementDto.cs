using InternetShop.Domain.Enums;

namespace InternetShop.Application.Dtos;

public record class EditAnnouncementDto
(
    decimal Price,
    int Quantity,
    AnnouncementStatus AnnouncementStatus
);