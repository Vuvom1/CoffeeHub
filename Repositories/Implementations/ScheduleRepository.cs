using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
{
    private new readonly CoffeeHubContext _context;
    public ScheduleRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}
