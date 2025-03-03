using System;

namespace CoffeeHub.Models;

public class Shift : BaseEntity
{
    public string Name { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
}
