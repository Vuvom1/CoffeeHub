using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IIngredientService : IBaseService<Ingredient>
{
    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids);
    public Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync();
    public Task<Ingredient> UpdateStockAsync(Guid ingredientId, decimal quantity);
    public Task<Ingredient> IncreaseStockAsync(Guid ingredientId, decimal quantity);  
    public Task<Ingredient> DecreaseStockAsync(Guid ingredientId, decimal quantity);
}
