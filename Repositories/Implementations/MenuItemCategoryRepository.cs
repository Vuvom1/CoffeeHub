using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class MenuItemCategoryRepository(CoffeeHubContext context) : BaseRepository<MenuItemCategory>(context), IMenuItemCategoryRepository
{
    private new readonly CoffeeHubContext _context = context;

    public Task<IEnumerable<MenuItemCategory>> GetAllWithMenuItemsAsync()
    {
        return Task.FromResult(_context.MenuItemCategories.Include(x => x.MenuItems).AsEnumerable());
    }

    public Task<MenuItemCategory> GetByNameWithMenuItemsAsync(string Name)
    {
        var menuItemCategory = _context.MenuItemCategories.Include(x => x.MenuItems).FirstOrDefault(x => x.Name == Name);
        if (menuItemCategory == null)
        {
            throw new InvalidOperationException($"MenuItemCategory with name {Name} not found.");
        }
        return Task.FromResult(menuItemCategory);
    }
}
