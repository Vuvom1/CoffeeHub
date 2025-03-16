using System;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.Domains
{
    public class Employee : BaseEntity
{
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public required string Address { get; set; }
    public EmployeeRole Role { get; set; }
    public required DateTime DateStartWork { get; set; }
    public Guid AuthId { get; set; }
    public virtual Auth Auth { get; set; } = null!;
    public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}

}

