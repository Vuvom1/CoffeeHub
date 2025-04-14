using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
{
    private new readonly CoffeeHubContext _context;
    public ShiftRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public Task<Dictionary<Shift, decimal>> GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate)
    {
        var totalSchedulesTimeByShifts = _context.Shifts
            .Include(s => s.Schedules)
            .AsEnumerable()
            .Where(s => s.Schedules != null)
            .ToDictionary(s => s, s => s.Schedules
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .Sum(s => (decimal)(s.Shift.EndTime - s.Shift.StartTime).TotalHours));
        
        return Task.FromResult(totalSchedulesTimeByShifts);
    }
}
