using System;

namespace CoffeeHub.Models.Domains;

public class Schedule : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid ShiftId { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    public virtual Shift Shift { get; set; } = null!;
}
