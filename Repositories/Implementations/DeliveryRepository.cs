using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
{
    private readonly CoffeeHubContext _context;
    public DeliveryRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public Task<Delivery?> GetWithOrderAsync(Guid id)
    {
        return _context.Deliveries.Include(x => x.Order).FirstOrDefaultAsync(x => x.Id == id);
    }
}
