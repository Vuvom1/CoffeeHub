using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IStatisticService
{
    Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate);
    Task<int> GetTotalOrderQuantityAsync(DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalStockCostAsync(DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalStockQuantityAsync(DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalProfitAsync(DateTime startDate, DateTime endDate);
    Task<Dictionary<Shift, decimal>> GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Ingredient>> GetIngredientsWithLowStockAsync(int limit);
    Task<IEnumerable<Ingredient>> GetIngredientsWithHighStockAsync(int limit);
    Task<IEnumerable<Ingredient>> GetIngredientsWithZeroStockAsync(int limit);
    Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByDaysAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByMonthsAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByYearsAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<MenuItem>> GetPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit);
    Task<IEnumerable<MenuItem>> GetLeastPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit);
}
