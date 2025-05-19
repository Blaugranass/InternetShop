using System.Security.Cryptography.X509Certificates;
using InternetShop.Domain.Entities;

namespace InternetShop.Application.Dtos.Announcements;

public record CreateAnnouncementAccessoryDto
(   
    decimal Price,
    Accessory Accessory,
    int Quantity
);
