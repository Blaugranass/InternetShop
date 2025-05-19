using System;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Infrastructure.Repositories;

public class ClientReposiory(ShopDbContext dbContext) : Repository<Client>(dbContext), IClientRepository
{
    private readonly ShopDbContext _dbContext = dbContext;

    public async Task<bool> ExistsWithNumber(string number, CancellationToken cancellationToken)
    {
        return await _dbContext.Clients
            .AsNoTracking()
            .AnyAsync(u => u.PhoneNumber == number, cancellationToken);
    } 

    public async Task<bool> ExistWithMail(string mail, CancellationToken cancellationToken)
    {
        return await _dbContext.Clients
            .AsNoTracking()
            .AnyAsync(u => u.Mail == mail, cancellationToken);
    }

    public async Task<Client> GetByMailAsync(string mail, CancellationToken cancellationToken)
    {
        return await _dbContext.Clients
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Mail == mail,cancellationToken) ?? throw new Exception("Not found");
    }

}
