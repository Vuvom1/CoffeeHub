using System;
using CoffeeHub.Models.DTOs.EmployeeDtos;
using CoffeeHub.Models.DTOs.ShiftDtos;

namespace CoffeeHub.Models.DTOs.ScheduleDtos;

public class ScheduleDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ShiftId { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; } = null!;
    public virtual EmployeeDto Employee { get; set; } = null!;
    public virtual ShiftDto Shift { get; set; } = null!;
}
