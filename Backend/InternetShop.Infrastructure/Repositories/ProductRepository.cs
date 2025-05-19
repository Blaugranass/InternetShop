using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class ProductRepository(ShopDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{

    private readonly ShopDbContext _dbContext = dbContext;
    
    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Products
            .Where(p => p.Id == product.Id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(p => p.Name, product.Name)
            .SetProperty(p => p.Description, product.Description),
            cancellationToken);

    }

}