using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public interface IMenuItemCategoryRepository : IBaseRepository<MenuItemCategory>
{
    Task<IEnumerable<MenuItemCategory>> GetAllWithMenuItemsAsync();
    Task<MenuItemCategory> GetByNameWithMenuItemsAsync(string name);
}
