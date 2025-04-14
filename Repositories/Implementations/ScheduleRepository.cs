using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
{
    private new readonly CoffeeHubContext _context;
    public ScheduleRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }


    public Task<decimal> GetTotalSchedulesTimeByShiftAsync(Guid shiftId, DateTime startDate, DateTime endDate)
    {
        var totalSchedulesTime = _context.Schedules
            .Where(s => s.ShiftId == shiftId && s.Date >= startDate && s.Date <= endDate)
            .AsEnumerable()
            .Where(s => s.Shift != null)
            .Sum(s => (decimal)(s.Shift.EndTime - s.Shift.StartTime).TotalHours);

        return Task.FromResult(totalSchedulesTime);
    }

    public Task<Dictionary<Shift, decimal>> GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate)
    {
        var totalSchedulesTimeByShifts = _context.Schedules
            .Where(s => s.Date >= startDate && s.Date <= endDate)
            .Include(s => s.Shift)
            .AsEnumerable()
            .Where(s => s.Shift != null)
            .GroupBy(s => s.Shift)
            .ToDictionary(g => g.Key, g => g.Sum(s => (decimal)(s.Shift.EndTime - s.Shift.StartTime).TotalHours));

        return Task.FromResult(totalSchedulesTimeByShifts);
    }
}
