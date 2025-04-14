using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<Dictionary<Shift, decimal>> GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate);
}
