using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByStatusesAsync(IEnumerable<OrderStatus> orderStatuses);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<decimal> GetTotalOderRevenueAsync(DateTime startDate, DateTime endDate);
    Task<int> GetTotalOrderQuantityAsync(DateTime startDate, DateTime endDate);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
}
