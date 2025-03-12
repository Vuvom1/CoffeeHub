using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    public Task<IEnumerable<Recipe>> GetByMenuItemIdAsync(Guid menuItemId);
    public Task UpdateByMenuItemAsync(Guid menuItemId, Recipe[] recipes);
}
