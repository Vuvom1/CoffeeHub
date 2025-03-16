using System;

namespace CoffeeHub.Models.DTOs.ShiftDtos;

public class ShiftAddDto
{
    public string Name { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
