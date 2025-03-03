using System;

namespace CoffeeHub.Models;

public class Schedule : BaseEntity
{
    public string? EmployeeId { get; set; }
    public string? ShiftId { get; set; }
    public DateOnly Date { get; set; }
    public string Note { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;
    public virtual Shift Shift { get; set; } = null!;
}
