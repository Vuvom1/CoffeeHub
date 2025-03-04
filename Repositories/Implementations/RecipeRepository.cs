using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    private new readonly CoffeeHubContext _context;
    public RecipeRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}
