using System;

namespace InternetShop.Domain.Entities;

public class CartItem
{
    public Guid? AnnouncementId;
    
    public Announcement? Announcement { get; set; }

    public int Quantity { get; set; } = 0;

    public decimal Price { get; set; } 

}