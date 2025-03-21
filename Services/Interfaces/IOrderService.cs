using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task<IEnumerable<Order>> GetPendingOrProcessingOrdersAsync();
    Task<IEnumerable<Order>> GetProcessingOrPreparingOrdersAsync();
    Task<IEnumerable<Order>> GetReadyOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task UpadateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
    Task CancelOrderAsync(Guid orderId);
    Task StartProcessingOrderAsync(Guid orderId);
    Task StartPreparingOrderAsync(Guid orderId);
    Task MarkOrderAsReadyAsync(Guid orderId);
    Task CompleteOrderAsync(Guid orderId);
}
