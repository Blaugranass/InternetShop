using System;
using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface IClientRepository : IRepository<Client>
{
    Task<bool> ExistWithMail(string mail, CancellationToken cancellationToken = default);

    Task<bool> ExistsWithNumber(string number, CancellationToken cancellationToken = default);

    Task<Client> GetByMailAsync(string mail, CancellationToken cancellationToken = default);
};
