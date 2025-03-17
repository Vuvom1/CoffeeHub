using System;

namespace CoffeeHub.Models.DTOs.StatisticDtos;

public class FinanceStatisticDto
{
    public decimal TotalRevenue { get; set; }
    public decimal TotalStockCost { get; set; }
    public decimal TotalProfit { get; set; }
}
