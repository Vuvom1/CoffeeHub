using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients.Include(i => i.IngredientCategory).ToListAsync();
    }

    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return _context.Ingredients.Where(i => ids.Contains(i.Id)).ToListAsync();
    }

    public Task<IEnumerable<Ingredient>> GetHighestQuantityAsync(int limit)
    {
        var ingredients = _context.Ingredients
            .Where(i => i.TotalQuantity == _context.Ingredients.Max(i => i.TotalQuantity))
            .Take(limit)
            .OrderByDescending(i => i.TotalQuantity)
            .ThenBy(i => i.Name)
            .AsEnumerable();

        return Task.FromResult(ingredients);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsWithZeroStockAsync(int limit)
    {
        var ingredients = _context.Ingredients
            .Where(i => i.TotalQuantity == 0)
            .Take(limit)
            .OrderBy(i => i.Name)
            .AsEnumerable();

        return Task.FromResult(ingredients);
    }

    public Task<IEnumerable<Ingredient>> GetLowestQuantityAsync(int limit)
    {
        var ingredients = _context.Ingredients
            .Where(i => i.TotalQuantity == _context.Ingredients.Min(i => i.TotalQuantity))
            .Take(limit)
            .OrderBy(i => i.TotalQuantity)
            .ThenBy(i => i.Name)
            .AsEnumerable();

        return Task.FromResult(ingredients);
    }

    public async Task<bool> IsEnoughAsync(Dictionary<Guid, int> ingredientQuantities)
    {
        foreach (var ingredientQuantity in ingredientQuantities)
        {
            var ingredient = await _context.Ingredients.FindAsync(ingredientQuantity.Key);

            if (ingredient == null || ingredient.TotalQuantity < ingredientQuantity.Value)
            {
                return false;
            }
        }

        return true;
    }
}