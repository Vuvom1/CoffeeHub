using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientCategoryRepository : BaseRepository<IngredientCategory>, IIngredientCategoryRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientCategoryRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}