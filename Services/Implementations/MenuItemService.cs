using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Implementations;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class MenuItemService : BaseService<MenuItem>, IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMenuItemHistoryRepository _menuItemHistoryRepository;
    public MenuItemService(
        IMenuItemRepository menuItemRepository, 
        IRecipeRepository recipeRepository,
        IMenuItemHistoryRepository menuItemHistoryRepository) : base(menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
        _recipeRepository = recipeRepository;
        _menuItemHistoryRepository = menuItemHistoryRepository;
    }

    public async Task<MenuItem> UpdateMenuItemAvailabilityAsync(Guid id)
    {
        return await _menuItemRepository.UpdateAvailabilityAsync(id);
    }

    public async Task UpdateMenuItemRecipesAsynce(Guid id, IEnumerable<Recipe> menuItemRecipes)
    {
        var menuItem = _menuItemRepository.GetByIdAsync(id);
        var existingRecipes = await _recipeRepository.FindAsync(r => r.MenuItemId == id);
        foreach (var recipe in existingRecipes)
        {
            await _recipeRepository.DeleteAsync(recipe);
        }

        foreach (var recipe in menuItemRecipes)
        {
            await _recipeRepository.AddAsync(recipe);
        }
    }

    Task<IEnumerable<MenuItem>> IMenuItemService.GetPopularMenuItemsAsync(int limit)
    {
        return _menuItemRepository.GetPopularMenuItemsAsync(limit);
    }

    public async Task<IEnumerable<MenuItem>> GetNewestMenuItemsAsync(int limit)
    {
        return await _menuItemRepository.GetNewestMenuItemsAsync(limit);
    }

    public async Task<MenuItem?> GetByNameAsync(string name)
    {
        return await _menuItemRepository.GetByNameAsync(name);
    }

    public override async Task UpdateAsync(MenuItem entity)
    {
        // Save the old menu item to history
        var oldMenuItem = await _menuItemRepository.GetByIdAsync(entity.Id);
        if (oldMenuItem != null)
        {
            var menuItemHistory = new MenuItemHistory
            {
                MenuItemId = oldMenuItem.Id,
                Name = oldMenuItem.Name,
                Description = oldMenuItem.Description,
                Price = oldMenuItem.Price,
                ImageUrl = oldMenuItem.ImageUrl,
                IsAvailable = oldMenuItem.IsAvailable,
                MenuItemCategoryId = oldMenuItem.MenuItemCategoryId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _menuItemHistoryRepository.AddAsync(menuItemHistory);
        }

        // Update the menu ite
        await base.UpdateAsync(entity);
    }

    public async Task<IEnumerable<MenuItemHistory>> GetMenuItemHistoryAsync(Guid menuItemId)
    {
        return await _menuItemHistoryRepository.GetByMenuItemIdAsync(menuItemId);
    }
}
