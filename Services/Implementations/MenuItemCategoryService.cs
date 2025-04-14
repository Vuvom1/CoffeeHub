using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Implementations;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class MenuItemCategoryService : BaseService<MenuItemCategory>, IMenuItemCategoryService
{
    private readonly IMenuItemCategoryRepository _menuItemCategoryRepository;
    public MenuItemCategoryService(IMenuItemCategoryRepository menuItemCategoryRepository) : base(menuItemCategoryRepository)
    {
        _menuItemCategoryRepository = menuItemCategoryRepository;
    }

    public async Task<IEnumerable<MenuItemCategory>> GetAllWithMenuItemsAsync()
    {
        return await _menuItemCategoryRepository.GetAllWithMenuItemsAsync();
    }

    public Task<MenuItemCategory> GetByNameWithMenuItemsAsync(string name)
    {
        return _menuItemCategoryRepository.GetByNameWithMenuItemsAsync(name);
    }
}
