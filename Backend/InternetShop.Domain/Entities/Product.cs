using System.Text.Json.Serialization;

namespace InternetShop.Domain.Entities;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Accessory), "accessory")]
public abstract class Product : BaseEntity
{
    public string Name {get; set; } = string.Empty;

    public string Discription {get; set; } = string.Empty;

}
