using System;
using InternetShop.Domain.Enums;

namespace InternetShop.Domain.Entities;

public class Announcement : BaseEntity
{
    public int MaxQuantity  { get; } = 9;
    public AnnouncementStatus Status { get; set; }

    public Guid ProductId { get; set; }
    
    public Product? Product { get; set; } 

    public int Quantity { get; set;} 

    public DateTime CreatedAt { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsActive()
    {
        return Status == AnnouncementStatus.Active;
    }
}