using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IMenuItemService : IBaseService<MenuItem>
{
    public Task<IEnumerable<MenuItem>> GetPopularMenuItemsAsync(int limit);
    public Task<MenuItem?> GetByNameAsync(string name);
    public Task<IEnumerable<MenuItem>> GetNewestMenuItemsAsync(int limit);
    public Task<MenuItem> UpdateMenuItemAvailabilityAsync(Guid id);
    public Task UpdateMenuItemRecipesAsynce(Guid id, IEnumerable<Recipe> menuItemRecipes);
}
