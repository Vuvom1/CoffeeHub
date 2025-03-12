using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models;

public class Admin : BaseEntity
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public string? Address { get; set; }
    public Guid? AuthId { get; set; }
    public virtual Auth Auth { get; set; } = null!;

}
