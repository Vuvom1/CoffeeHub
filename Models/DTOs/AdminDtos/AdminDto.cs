using System;

namespace CoffeeHub.Models.DTOs.AdminDtos;

public class AdminDto
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public string? Address { get; set; }
    public Guid? AuthId { get; set; }
}
