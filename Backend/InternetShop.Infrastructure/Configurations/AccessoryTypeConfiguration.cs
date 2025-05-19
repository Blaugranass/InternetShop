

using System.Data.Common;
using InternetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Infrastructure.Configurations;

public class AccessoryTypeConfiguration : IEntityTypeConfiguration<AccessoryType>
{
    public void Configure(EntityTypeBuilder<AccessoryType> builder)
    {
        builder.ToTable("AccessoryTypes");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData
        (
            new AccessoryType { Id = Guid.NewGuid(), Type = "Наушники"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Клавиатура"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Монитор"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Коврик для мыши"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Мышь"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Web-камеры"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Микрофон"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Внешний накопитель"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Кабель"},
            new AccessoryType { Id = Guid.NewGuid(), Type = "Адаптер"}
        );

    }

}