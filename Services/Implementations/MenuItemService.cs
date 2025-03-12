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
    public MenuItemService(IMenuItemRepository menuItemRepository, IRecipeRepository recipeRepository) : base(menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
        _recipeRepository = recipeRepository;
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
}
