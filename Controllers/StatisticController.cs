using AutoMapper;
using CoffeeHub.Models.DTOs.IngredientDtos;
using CoffeeHub.Models.DTOs.ShiftDtos;
using CoffeeHub.Models.DTOs.StatisticDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;
        public StatisticController(IStatisticService statisticService, IMapper mapper)
        {
            _statisticService = statisticService;
            _mapper = mapper;
        }

        // GET: api/Statistic/TotalOrderRevenue
        [HttpGet("Finance")]
        public async Task<IActionResult> GetTotalOrderRevenue([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            var totalRevenue = await _statisticService.GetTotalRevenueAsync(startDate, endDate);
            var totalStockCost = await _statisticService.GetTotalStockCostAsync(startDate, endDate);
            var totalProfit = await _statisticService.GetTotalProfitAsync(startDate, endDate);

            var financialStatistic = new FinanceStatisticDto
            {
                TotalRevenue = totalRevenue,
                TotalStockCost = totalStockCost,
                TotalProfit = totalProfit
            };

            return Ok(financialStatistic);
        }

        // GET: api/Statistic/TotalScheduleTime
        [HttpGet("Schedule")]
        public async Task<IActionResult> GetTotalScheduleTime([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var totalSchedulesTimeByShifts = await _statisticService.GetTotalSchedulesTimeByShiftsAsync(startDate, endDate);

            var scheduleStatisticDtos = totalSchedulesTimeByShifts.Select(kvp => new ScheduleStatisticDto
            {
                Shift = _mapper.Map<ShiftDto>(kvp.Key),
                TotalTime = kvp.Value
            }).ToList();

            return Ok(scheduleStatisticDtos);
        }

        // GET: api/Statistic/HighestLowestStock
        [HttpGet("Stock")]
        public async Task<IActionResult> GetHighestLowestStock([FromQuery] int limit)
        {
            var ingredientsWithLowStock = await _statisticService.GetIngredientsWithLowStockAsync(limit);
            var ingredientsWithHighStock = await _statisticService.GetIngredientsWithHighStockAsync(limit);

            var stockStatistic = new StockStatisticDto
            {
                IngredientsWithLowStock = _mapper.Map<IEnumerable<IngredientDto>>(ingredientsWithLowStock),
                IngredientsWithHighStock = _mapper.Map<IEnumerable<IngredientDto>>(ingredientsWithHighStock)
            };

            return Ok(stockStatistic);
        }

        // GET: api/Statistic/DailyFinancial
        [HttpGet("DailyFinancial")]
        public async Task<IActionResult> GetDailyFinancial([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var financialStatisticByDays = await _statisticService.GetFinancialStatisticByDaysAsync(startDate, endDate);

            return Ok(financialStatisticByDays);
        }

        // GET: api/Statistic/MonthlyFinancial
        [HttpGet("MonthlyFinancial")]
        public async Task<IActionResult> GetMonthlyFinancial([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var financialStatisticByMonths = await _statisticService.GetFinancialStatisticByMonthsAsync(startDate, endDate);

            return Ok(financialStatisticByMonths);
        }

        // GET: api/Statistic/YearlyFinancial
        [HttpGet("YearlyFinancial")]
        public async Task<IActionResult> GetYearlyFinancial([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var financialStatisticByYears = await _statisticService.GetFinancialStatisticByYearsAsync(startDate, endDate);

            return Ok(financialStatisticByYears);
        }

        // GET: api/Statistic/PopularMenuItems
        [HttpGet("PopularMenuItems")]
        public async Task<IActionResult> GetPopularMenuItems([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int limit)
        {
            var popularMenuItems = await _statisticService.GetPopularMenuItemsByTimeAsync(startDate, endDate, limit);

            return Ok(popularMenuItems);
        }

        // GET: api/Statistic/LeastPopularMenuItems
        [HttpGet("LeastPopularMenuItems")]
        public async Task<IActionResult> GetLeastPopularMenuItems([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int limit)
        {
            var leastPopularMenuItems = await _statisticService.GetLeastPopularMenuItemsByTimeAsync(startDate, endDate, limit);

            return Ok(leastPopularMenuItems);
        }


    }
}
