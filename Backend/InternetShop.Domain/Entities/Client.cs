using System;

namespace InternetShop.Domain.Entities;

public class Client : BaseEntity
{
    public string Mail { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string HashPassword { get; set; } = string.Empty;

    public Cart? Cart { get; set; } 

    public List<Announcement> Favourites { get; set; } = [];
}
