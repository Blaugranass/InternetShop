using System;

namespace InternetShop.Domain.Entities;

public class Admin : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string HashPassword { get; set; } = string.Empty;
}
