using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
    
}
