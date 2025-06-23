using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IMenuItemHistoryRepository : IBaseRepository<MenuItemHistory>
{
    Task<IEnumerable<MenuItemHistory>> GetByMenuItemIdAsync(Guid menuItemId);
}
