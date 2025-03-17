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