using System;

namespace InternetShop.Domain.Entities;

public class CartItem
{
    public static int MaxQuanityAnnouncements = 10; 

    public Announcement? Announcement { get; set; }

    public int Quanity { get; set; } = 0;

    public decimal Price { get; set; } = 0m;

}