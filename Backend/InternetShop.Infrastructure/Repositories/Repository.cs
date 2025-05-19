using System.Linq.Expressions;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class Repository<T>(ShopDbContext dbContext) : IRepository<T> where T : BaseEntity
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>()
            .AddAsync(entity, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>()
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .Where(e => e.Id == id) 
            .FirstAsync(cancellationToken);
    }

}
