using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    new Task<IEnumerable<Ingredient>> GetAllAsync();
    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids);
    public Task<IEnumerable<Ingredient>> GetHighestQuantityAsync(int limit);
    public Task<IEnumerable<Ingredient>> GetLowestQuantityAsync(int limit);
    public Task<IEnumerable<Ingredient>> GetIngredientsWithZeroStockAsync(int limit);
    public Task<IEnumerable<Ingredient>> GetIngredientsWithLowStockAsync();
    public Task<bool> IsEnoughAsync(Dictionary<Guid, int> ingredientQuantities);
}
