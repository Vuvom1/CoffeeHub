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

    public Task<decimal> GetTotalSchedulesTimeByShiftAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetTotalSchedulesTimeByShiftAsync(Guid shiftId, DateTime startDate, DateTime endDate)
    {
        var totalSchedulesTime = _context.Schedules
            .Where(s => s.ShiftId == shiftId && s.Date >= startDate && s.Date <= endDate)
            .AsEnumerable()
            .Sum(s => (decimal)(s.Shift.EndTime - s.Shift.StartTime).TotalHours);

        return Task.FromResult(totalSchedulesTime);
    }
}
