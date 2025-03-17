using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<decimal> GetTotalOderRevenueAsync(DateTime startDate, DateTime endDate);
    Task<int> GetTotalOrderQuantityAsync(DateTime startDate, DateTime endDate);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
}
