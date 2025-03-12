using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task AddWithDetailsAsync(Order order, IEnumerable<OrderDetail> orderDetails);
}
