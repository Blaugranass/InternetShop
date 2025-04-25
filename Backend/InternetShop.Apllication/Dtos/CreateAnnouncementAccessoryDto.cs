using System.Security.Cryptography.X509Certificates;
using InternetShop.Domain.Entities;

namespace InternetShop.Application.Dtos;

public record class CreateAnnouncementAccessoryDto
(   
    decimal Price,
    Accessory Accessory,
    int Quantity
);
