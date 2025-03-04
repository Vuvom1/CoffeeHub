using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class OrderDetailRepository(CoffeeHubContext context) : BaseRepository<OrderDetail>(context), IOrderDetailRepository
{
    private new readonly CoffeeHubContext _context = context;
}
