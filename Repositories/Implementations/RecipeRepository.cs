using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    private new readonly CoffeeHubContext _context;
    public RecipeRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recipe>> GetByMenuItemIdAsync(Guid menuItemId)
    {
        return await _context.Recipes
            .Include(r => r.Ingredient)
            .Where(r => r.MenuItemId == menuItemId)
            .ToListAsync();
    }

    public async Task UpdateByMenuItemAsync(Guid menuItemId, Recipe[] recipes)
    {
        var oldRecipes = _context.Recipes.Where(r => r.MenuItemId == menuItemId);
        _context.Recipes.RemoveRange(oldRecipes);
        foreach (var recipe in recipes)
        {
            recipe.MenuItemId = menuItemId;
        }
        await _context.Recipes.AddRangeAsync(recipes);
        await _context.SaveChangesAsync();
    }
}
