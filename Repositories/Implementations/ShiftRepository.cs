using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
{
    private new readonly CoffeeHubContext _context;
    public ShiftRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}
