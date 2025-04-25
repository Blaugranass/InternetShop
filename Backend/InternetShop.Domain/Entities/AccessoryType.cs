using System;

namespace InternetShop.Domain.Entities;

public class AccessoryType
{
    public Guid Id; 

    public string Type {get; set; } = string.Empty;
}
