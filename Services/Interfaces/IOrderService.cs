using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task<IEnumerable<Order>> GetAllViewableByUserId(Guid id);   
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task UpadateOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
}
