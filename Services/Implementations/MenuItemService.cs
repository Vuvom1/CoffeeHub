using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Implementations;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class MenuItemService : BaseService<MenuItem>, IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    public MenuItemService(IMenuItemRepository menuItemRepository) : base(menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }
}
