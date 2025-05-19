using System;

namespace InternetShop.Domain.Entities;

public class Accessory : Product
{
    public Guid AccessoryTypeId;

    public AccessoryType? Type {get; set; }

}