using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IMenuItemService : IBaseService<MenuItem>
{
    public Task<MenuItem> UpdateMenuItemAvailabilityAsync(Guid id);
    public Task UpdateMenuItemRecipesAsynce(Guid id, IEnumerable<Recipe> menuItemRecipes);
}
