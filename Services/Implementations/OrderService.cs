using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class OrderService(IOrderRepository orderRepository) : BaseService<Order>(orderRepository), IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
}