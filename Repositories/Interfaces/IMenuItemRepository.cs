using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IMenuItemRepository : IBaseRepository<MenuItem>
{
    Task<IEnumerable<MenuItem>> GetPopularMenuItemsAsync(int limit);

    Task<IEnumerable<MenuItem>> GetPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit);
    Task<IEnumerable<MenuItem>> GetLeastPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit);
    Task<IEnumerable<MenuItem>> GetNewestMenuItemsAsync(int limit);
    Task<MenuItem?> GetByNameAsync(string name);
    Task<MenuItem> UpdateAvailabilityAsync(Guid id);
    Task<decimal> GetPriceByIdAsync(Guid id);
    Task<bool> IsActivatedAsync(Guid id);
}
