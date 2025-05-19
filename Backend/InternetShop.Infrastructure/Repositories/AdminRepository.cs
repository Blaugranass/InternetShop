using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class AdminRepository(ShopDbContext dbContext) : Repository<Admin>(dbContext), IAdminRepository
{

    private readonly ShopDbContext _dbContext = dbContext;
    public async Task<Admin> GetByNameAsync(string name)
    {
        return await _dbContext.Admins
            .AsNoTracking()
            .FirstAsync(a=> a.Name == name);
    }
}
