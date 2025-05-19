namespace InternetShop.Application.Dtos.Announcements;

public record class AnnouncementUserDto
(
    Guid Id,
    int Quantity,
    decimal Price,
    string ImageUrl
);