using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IIngredientStockRepository : IBaseRepository<IngredientStock>
{
    Task<decimal> GetTotalStockQuantityAsync(DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalStockCostAsync(DateTime startDate, DateTime endDate);
}
