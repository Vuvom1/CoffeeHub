using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class OrderRepository(CoffeeHubContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private new readonly CoffeeHubContext _context = context;
}
