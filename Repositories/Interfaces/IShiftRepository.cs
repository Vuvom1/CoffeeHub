using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IShiftRepository : IBaseRepository<Shift>
{
    Task<Dictionary<Shift, decimal>> GetTotalSchedulesTimeByShiftsAsync(DateTime startDate, DateTime endDate);
}
