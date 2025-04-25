using System;
using InternetShop.Domain.Enums;

namespace InternetShop.Domain.Entities;

public class Announcement : BaseEntity
{
    public AnnouncementStatus Status { get; set; }

    public Product? Product { get; set; } 

    public int Quantity { get; set;} 

    public DateTime CreatedAt { get; set; }

    public decimal Price { get; set; }

}