using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Table : BaseEntity
{
    public int Number { get; set; }
    public int Capacity { get; set; }
    public TableStatus Status { get; set; }
    public virtual ICollection<TableBooking> TableBookings { get; set; } = new HashSet<TableBooking>();
}
