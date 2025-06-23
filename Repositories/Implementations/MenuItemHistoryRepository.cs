using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class MenuItemHistoryRepository : BaseRepository<MenuItemHistory>, IMenuItemHistoryRepository
{
    private new readonly CoffeeHubContext _context;
    public MenuItemHistoryRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuItemHistory>> GetByMenuItemIdAsync(Guid menuItemId)
    {
        return await _context.MenuItemHistories
            .Include(m => m.MenuItem)
            .Where(m => m.MenuItemId == menuItemId)
            .ToListAsync();
    }
}
