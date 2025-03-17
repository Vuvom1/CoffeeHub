using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class IngredientStockRepository : BaseRepository<IngredientStock>, IIngredientStockRepository
{
    private new readonly CoffeeHubContext _context;
    public IngredientStockRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<IngredientStock>> GetAllAsync()
    {
        return await _context.IngredientStocks
            .Include(i => i.Ingredient)
            .ToListAsync();
    }

    public Task<decimal> GetTotalStockCostAsync(DateTime startDate, DateTime endDate)
    {
        var totalStockCost = _context.IngredientStocks
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .Sum(i => i.TotalCostPrice);

        return Task.FromResult(totalStockCost);
    }

    public Task<decimal> GetTotalStockQuantityAsync(DateTime startDate, DateTime endDate)
    {
        var totalStockQuantity = _context.IngredientStocks
            .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
            .Sum(i => i.Quantity);

        return Task.FromResult(totalStockQuantity);
    }
}