using System;
using InternetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Infrastructure.Configurations;

public class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
{
    public void Configure(EntityTypeBuilder<Accessory> builder)
    {
        builder.ToTable("Accessories");

        builder.HasBaseType<Product>();

        builder.Property(a => a.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(a => a.Type)
            .WithMany()
            .HasForeignKey(a => a.AccessoryTypeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}