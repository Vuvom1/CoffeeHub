using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CoffeeHub.Services.Implementations;

public class IngredientService : BaseService<Ingredient>, IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    
    public IngredientService(IIngredientRepository ingredientRepository) : base(ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return _ingredientRepository.GetByIdsAsync(ids);
    }

    public Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync()
    {
        return _ingredientRepository.GetIngredientsWithLowStockAsync();
    }

    public async Task<Ingredient> IncreaseStockAsync(Guid ingredientId, decimal quantity)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);

        ingredient.TotalQuantity += quantity;

        await _ingredientRepository.UpdateAsync(ingredient);

        return ingredient;
    }

    public async Task<Ingredient> DecreaseStockAsync(Guid ingredientId, decimal quantity)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);

        ingredient.TotalQuantity -= quantity;

        await _ingredientRepository.UpdateAsync(ingredient);

        return ingredient;
    }

    public async Task<Ingredient> UpdateStockAsync(Guid ingredientId, decimal quantity)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);

        ingredient.TotalQuantity -= quantity;

        await _ingredientRepository.UpdateAsync(ingredient);

        return ingredient;
    }
}