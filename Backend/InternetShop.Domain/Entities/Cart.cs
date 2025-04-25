using System;

namespace InternetShop.Domain.Entities;

public class Cart : BaseEntity
{    
    public List<CartItem> Items {get; set; } = [];

    public decimal TotalCost { get; set; }
}
