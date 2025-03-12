using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Services.Implementations;

public class RecipeService : BaseService<Recipe>, IRecipeService

{
    private readonly IRecipeRepository _recipeRepository;
    public RecipeService(IRecipeRepository recipeRepository) : base(recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public Task<IEnumerable<Recipe>> GetByMenuItemIdAsync(Guid menuItemId)
    {
        return _recipeRepository.GetByMenuItemIdAsync(menuItemId);
    }

    public Task UpdateByMenuItemAsync(Guid menuItemId, Recipe[] recipes)
    {
        return _recipeRepository.UpdateByMenuItemAsync(menuItemId, recipes);
    }
}
