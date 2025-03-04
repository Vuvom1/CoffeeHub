using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}