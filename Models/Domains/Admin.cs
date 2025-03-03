using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeHub.Models;

public class Admin : BaseEntity
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public string? Address { get; set; }
    public long? AuthId { get; set; }
    public virtual Auth Auth { get; set; } = null!;

}
