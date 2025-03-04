using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class IngredientStockService : BaseService<IngredientStock>, IIngredientStockService
{
    private readonly IIngredientStockRepository _ingredientStockRepository;
    public IngredientStockService(IIngredientStockRepository ingredientStockRepository ) : base(ingredientStockRepository)
    {
        _ingredientStockRepository = ingredientStockRepository;
    }
}
