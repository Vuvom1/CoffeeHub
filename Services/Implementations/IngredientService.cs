using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class IngredientService : BaseService<Ingredient>, IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    public IngredientService(IIngredientRepository ingredientRepository ) : base(ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
}