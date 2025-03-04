using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class IngredientCategoryService : BaseService<IngredientCategory>, IIngredientCategoryService
{
    private readonly IIngredientCategoryRepository _ingredientRepository;
    public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository ) : base(ingredientCategoryRepository)
    {
        _ingredientRepository = ingredientCategoryRepository;
    }
}
