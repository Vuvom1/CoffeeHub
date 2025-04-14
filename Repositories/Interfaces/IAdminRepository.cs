using System;
using CoffeeHub.Models;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Repositories.Interfaces;

public interface IAdminRepository : IBaseRepository<Admin>
{
    public Task<Admin> GetWithAuthAsync(Guid id);
}
