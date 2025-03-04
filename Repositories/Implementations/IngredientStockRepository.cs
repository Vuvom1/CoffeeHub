using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientStockRepository : BaseRepository<IngredientStock>, IIngredientStockRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientStockRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}