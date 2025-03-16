using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class OrderDetailRepository(CoffeeHubContext context) : BaseRepository<OrderDetail>(context), IOrderDetailRepository
{
    private new readonly CoffeeHubContext _context = context;

    public Task AddManyAsync(IEnumerable<OrderDetail> orderDetails)
    {
        _context.OrderDetails.AddRange(orderDetails);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<decimal> CalculateTotalPriceAsync(Guid menuItemId, int quantity)
    {
        return Task.FromResult(_context.MenuItems.FirstOrDefault(x => x.Id == menuItemId)?.Price * quantity ?? 0);
    }
}
