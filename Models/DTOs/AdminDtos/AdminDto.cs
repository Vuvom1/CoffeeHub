using System;
using CoffeeHub.Models.DTOs.AuthDtos;

namespace CoffeeHub.Models.DTOs.AdminDtos;

public class AdminDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public string? Address { get; set; }
    public Guid? AuthId { get; set; }
    public virtual AuthDto? Auth { get; set; }
}
