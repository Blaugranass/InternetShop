using System;

namespace InternetShop.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }

    public List<CartItem> Items { get; private set; } = [];

    public decimal TotalCost { get; set; }

    public void AddItem(Announcement announcement, int quantity)
    {
        if (!announcement.IsActive())
            throw new ArgumentException("Item is not active");

        var item = Items.FirstOrDefault(i => i.Announcement == announcement);

        if (item!.Announcement!.Quantity < quantity || quantity > item!.Announcement!.MaxQuantity)
            throw new ArgumentException("Unavailable quantity of items");

        CartItem cartItem = new()
        {
            Announcement = announcement,
            AnnouncementId = announcement.Id,
            Quantity = quantity,
            Price = quantity * announcement.Price,
        };

        if (item is not null)
        {
            if (item.Quantity + quantity > item.Announcement.Quantity || item.Quantity + quantity > item.Announcement.MaxQuantity)
                throw new ArgumentException("Unavailable quantity of items");
        }

        Items.Add(cartItem);
        
    }
}
