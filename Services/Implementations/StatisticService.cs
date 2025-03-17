using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class StatisticService : IStatisticService
{
    private readonly IIngredientStockRepository _ingredientStockRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IShiftRepository _shiftRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    public StatisticService(
        IIngredientStockRepository ingredientStockRepository,
        IOrderRepository orderRepository,
        IScheduleRepository scheduleRepository,
        IIngredientRepository ingredientRepository,
        IShiftRepository shiftRepository,
        IMenuItemRepository menuItemRepository)
    {
        _ingredientStockRepository = ingredientStockRepository ?? throw new ArgumentNullException(nameof(ingredientStockRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
        _ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        _shiftRepository = shiftRepository ?? throw new ArgumentNullException(nameof(shiftRepository));
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public Task<int> GetTotalOrderQuantityAsync(DateTime startDate, DateTime endDate)
    {
        return _orderRepository.GetTotalOrderQuantityAsync(startDate, endDate);
    }

    public Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate)
    {
        return _orderRepository.GetTotalOderRevenueAsync(startDate, endDate);
    }

    public Task<decimal> GetTotalStockCostAsync(DateTime startDate, DateTime endDate)
    {
        return _ingredientStockRepository.GetTotalStockCostAsync(startDate, endDate);
    }

    public Task<decimal> GetTotalStockQuantityAsync(DateTime startDate, DateTime endDate)
    {
        return _ingredientStockRepository.GetTotalStockQuantityAsync(startDate, endDate);
    }

    public Task<decimal> GetTotalProfitAsync(DateTime startDate, DateTime endDate)
    {
        var totalRevenue = _orderRepository.GetTotalOderRevenueAsync(startDate, endDate).Result;
        var totalStockCost = _ingredientStockRepository.GetTotalStockCostAsync(startDate, endDate).Result;
        var totalNetProfit = totalRevenue - totalStockCost;
        
        return Task.FromResult(totalNetProfit);        
    }

    Task<Dictionary<Shift, decimal>> IStatisticService.GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate)
    {
        var shifts = _shiftRepository.GetAllAsync().Result;
        var totalSchedulesTimeByShifts = new Dictionary<Shift, decimal>();
        foreach (var shift in shifts)
        {
            var totalSchedulesTime = _scheduleRepository.GetTotalSchedulesTimeByShiftAsync(shift.Id, startDate, endDate).Result;
            totalSchedulesTimeByShifts.Add(shift, totalSchedulesTime);
        }

        return Task.FromResult(totalSchedulesTimeByShifts);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsWithLowStockAsync(int limit)
    {
        return _ingredientRepository.GetLowestQuantityAsync(limit);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsWithHighStockAsync(int limit)
    {
        return _ingredientRepository.GetHighestQuantityAsync(limit);
    }

    public Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByDaysAsync(DateTime startDate, DateTime endDate)
    {
        var financialStatisticByDays = new List<KeyValuePair<string, decimal>>();
        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            var totalRevenue = _orderRepository.GetTotalOderRevenueAsync(date, date.AddDays(1).AddTicks(-1)).Result;
            var totalStockCost = _ingredientStockRepository.GetTotalStockCostAsync(date, date.AddDays(1).AddTicks(-1)).Result;
            var totalProfit = totalRevenue - totalStockCost;
            financialStatisticByDays.Add(new KeyValuePair<string, decimal>(date.ToString("dd/MM/yyyy"), totalProfit));
        }

        return Task.FromResult<IEnumerable<KeyValuePair<string, decimal>>>(financialStatisticByDays);
    }

    public Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByMonthsAsync(DateTime startDate, DateTime endDate)
    {
        var financialStatisticByMonths = new List<KeyValuePair<string, decimal>>();
        for (var date = startDate; date <= endDate; date = date.AddMonths(1))
        {
            var totalRevenue = _orderRepository.GetTotalOderRevenueAsync(date, date.AddMonths(1).AddDays(-1)).Result;
            var totalStockCost = _ingredientStockRepository.GetTotalStockCostAsync(date, date.AddMonths(1).AddDays(-1)).Result;
            var totalProfit = totalRevenue - totalStockCost;
            financialStatisticByMonths.Add(new KeyValuePair<string, decimal>(date.ToString("MM/yyyy"), totalProfit));
        }

        return Task.FromResult<IEnumerable<KeyValuePair<string, decimal>>>(financialStatisticByMonths);
    }

    public Task<IEnumerable<KeyValuePair<string, decimal>>> GetFinancialStatisticByYearsAsync(DateTime startDate, DateTime endDate)
    {
        var financialStatisticByYears = new List<KeyValuePair<string, decimal>>();
        for (var date = startDate; date <= endDate; date = date.AddYears(1))
        {
            var totalRevenue = _orderRepository.GetTotalOderRevenueAsync(date, date.AddYears(1).AddDays(-1)).Result;
            var totalStockCost = _ingredientStockRepository.GetTotalStockCostAsync(date, date.AddYears(1).AddDays(-1)).Result;
            var totalProfit = totalRevenue - totalStockCost;
            financialStatisticByYears.Add(new KeyValuePair<string, decimal>(date.ToString("yyyy"), totalProfit));
        }

        return Task.FromResult<IEnumerable<KeyValuePair<string, decimal>>>(financialStatisticByYears);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsWithZeroStockAsync(int limit)
    {
        return _ingredientRepository.GetIngredientsWithZeroStockAsync(limit);
    }

    public Task<IEnumerable<MenuItem>> GetPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit)
    {
        return _menuItemRepository.GetPopularMenuItemsByTimeAsync(startDate, endDate, limit);
    }

    public Task<IEnumerable<MenuItem>> GetLeastPopularMenuItemsByTimeAsync(DateTime startDate, DateTime endDate, int limit)
    {
        return _menuItemRepository.GetLeastPopularMenuItemsByTimeAsync(startDate, endDate, limit);
    }
}
