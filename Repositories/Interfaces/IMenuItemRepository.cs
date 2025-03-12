using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IMenuItemRepository : IBaseRepository<MenuItem>
{
    new Task<IEnumerable<MenuItem>> GetAllAsync();
    Task<MenuItem> UpdateAvailabilityAsync(Guid id);
    Task<decimal> GetPriceByIdAsync(Guid id);
    Task<bool> IsActivatedAsync(Guid id);
}
