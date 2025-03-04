using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class ScheduleService : BaseService<Schedule>, IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    public ScheduleService(IScheduleRepository scheduleRepository ) : base(scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
}