using InternetShop.Domain.Entities;

namespace InternetShop.Application.Dtos;

public record class AddItemInCartDto
(
    Guid AnnouncementId,
    int Quantity
);