using System;
using System.Net.Http.Headers;
using InternetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure;

public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Announcement> Announcements { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Cart> Carts{ get; set; }

    public DbSet<CartItem> Items { get; set; }
}
