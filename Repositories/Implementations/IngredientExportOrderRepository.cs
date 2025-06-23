using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientExportOrderRepository : BaseRepository<IngredientExportOrder>, IIngredientExportOrderRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientExportOrderRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<IngredientExportOrder>> GetAllAsync()
    {
        return await _context.IngredientExportOrders
            .Include(x => x.IngredientStock)
            .ThenInclude(x => x!.Ingredient)
            .ToListAsync();
    }
}
