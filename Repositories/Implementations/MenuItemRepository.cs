using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
{
    private new readonly CoffeeHubContext _context;
    public MenuItemRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}
