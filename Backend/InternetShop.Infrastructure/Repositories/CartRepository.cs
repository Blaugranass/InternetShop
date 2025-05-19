using System;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class CartRepository(ShopDbContext dbContext) : Repository<Cart>(dbContext), ICartRepository
{

    private readonly ShopDbContext _dbContext = dbContext;

    public async Task<Cart> GetToUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var cart =  await _dbContext.Carts
            .AsNoTracking()
            .Include(i=> i.Items)
            .FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);

        return cart ?? new Cart{ UserId = userId };
            
    }

    public async Task UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _dbContext.Carts
            .Where(c => c.Id == cart.Id)
            .ExecuteUpdateAsync(pr => pr
                .SetProperty(c => c.TotalCost, cart.TotalCost)
                .SetProperty(c => c.Items, cart.Items), cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
