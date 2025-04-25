using System;
using System.Linq.Expressions;
using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T,bool>> expression,
        CancellationToken cancellationToken = default);
}
