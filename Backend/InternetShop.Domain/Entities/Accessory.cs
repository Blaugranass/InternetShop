using System;

namespace InternetShop.Domain.Entities;

public class Accessory : Product
{
    public string Description {get; set; } = string.Empty;

    public Guid AccessoryTypeId;

    public AccessoryType? Type {get; set; }

}