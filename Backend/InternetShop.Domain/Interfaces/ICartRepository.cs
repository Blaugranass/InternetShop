using System;
using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> GetToUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task UpdateAsync(Cart cart, CancellationToken cancellationToken= default);
}
