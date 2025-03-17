using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<decimal> GetTotalSchedulesTimeByShiftAsync( Guid shiftId, DateTime startDate, DateTime endDate); 
}
