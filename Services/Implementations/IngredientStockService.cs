using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class IngredientStockService : BaseService<IngredientStock>, IIngredientStockService
{
    private readonly IIngredientStockRepository _ingredientStockRepository;
    private readonly IIngredientRepository _ingredientRepository;
    public IngredientStockService(IIngredientStockRepository ingredientStockRepository, IIngredientRepository ingredientRepository) : base(ingredientStockRepository)
    {
        _ingredientStockRepository = ingredientStockRepository;
        _ingredientRepository = ingredientRepository;
    }

    public override async Task AddAsync(IngredientStock entity)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(entity.IngredientId);
        if (ingredient == null)
        {
            throw new Exception("Ingredient not found");
        }

        ingredient.TotalQuantity += entity.Quantity;
        await _ingredientRepository.UpdateAsync(ingredient);

        await base.AddAsync(entity);
    }
}
