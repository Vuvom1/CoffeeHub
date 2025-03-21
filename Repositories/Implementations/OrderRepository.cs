using System;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class OrderRepository(CoffeeHubContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private new readonly CoffeeHubContext _context = context;

    public override async Task<Order> GetByIdAsync(Guid id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.MenuItem)
            .Include(o => o.Employee)
            .Include(o => o.Customer)
            .Include(o => o.Promotion)
            .AsNoTracking()
            .SingleOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            throw new InvalidOperationException($"Order with id {id} not found.");
        }

        return order;
    }

    public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        var orders = _context.Orders
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.MenuItem)
            .Include(o => o.Delivery)
            .ToList();

        return Task.FromResult(orders.AsEnumerable());
    }

    public Task<IEnumerable<Order>> GetOrdersByStatusesAsync(IEnumerable<OrderStatus> orderStatuses)
    {
        var orders = _context.Orders
            .Where(o => orderStatuses.Contains(o.Status))
            .ToList();

        return Task.FromResult(orders.AsEnumerable());
    }

    public Task<decimal> GetTotalOderRevenueAsync(DateTime startDate, DateTime endDate)
    {
        var totalOrderRevenue = _context.Orders
            .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate && o.Status == OrderStatus.Completed)
            .Sum(o => o.FinalAmount);
        
        return Task.FromResult(totalOrderRevenue);
    }

    public Task<int> GetTotalOrderQuantityAsync(DateTime startDate, DateTime endDate)
    {
        var totalOrderQuantity = _context.Orders
            .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
            .Count();
        
        return Task.FromResult(totalOrderQuantity);
    }

    public Task UpdateOrderStatusAsync(Guid orderId, OrderStatus orderStatus)
    {
        var order = _context.Orders.Find(orderId);
        if (order == null)
        {
            throw new InvalidOperationException($"Order with id {orderId} not found.");
        }

        order.Status = orderStatus;
        _context.Orders.Update(order);
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}
