using System;

namespace CoffeeHub.Models.DTOs.ScheduleDtos;

public class ScheduleEditDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ShiftId { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; } = null!;
}
