using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Interfaces;

public interface IAdminRepository : IRepository<Admin>
{
    Task<Admin> GetByNameAsync(string name);
}