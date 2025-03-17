using System;
using CoffeeHub.Models.DTOs.ShiftDtos;

namespace CoffeeHub.Models.DTOs.StatisticDtos;

public class ScheduleStatisticDto
{
    public required ShiftDto Shift { get; set; }
    public decimal TotalTime { get; set; }    
}
