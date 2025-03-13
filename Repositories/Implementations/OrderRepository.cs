using System;
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
}
