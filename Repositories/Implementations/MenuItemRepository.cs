using System;
using CoffeeHub.Models;
using Microsoft.EntityFrameworkCore;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Implementations;

public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
{
    private new readonly CoffeeHubContext _context;
    public MenuItemRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _context.MenuItems.Include(x => x.MenuItemCategory).ToListAsync();
    }

    public async Task<decimal> GetPriceByIdAsync(Guid id)
    {
        return await Task.FromResult(_context.MenuItems.FirstOrDefault(x => x.Id == id)?.Price ?? 0);
    }

    public async Task<bool> IsActivatedAsync(Guid id)
    {
        return await Task.FromResult(_context.MenuItems.FirstOrDefault(x => x.Id == id)?.IsAvailable ?? false);
    }

    public async Task<MenuItem> UpdateAvailabilityAsync(Guid id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id) ?? throw new InvalidOperationException($"MenuItem with id {id} not found.");
        menuItem.IsAvailable = !menuItem.IsAvailable;
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
        return menuItem;
    }
}
