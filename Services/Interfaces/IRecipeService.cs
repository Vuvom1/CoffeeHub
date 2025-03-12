using System;
using CoffeeHub.Models.Domains;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Services.Interfaces;

public interface IRecipeService : IBaseService<Recipe>
{
    public Task<IEnumerable<Recipe>> GetByMenuItemIdAsync(Guid menuItemId);
    public Task UpdateByMenuItemAsync(Guid menuItemId, Recipe[] recipes);
}
