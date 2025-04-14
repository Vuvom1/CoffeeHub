using System;

namespace CoffeeHub.Models.DTOs.AdminDtos;

public class AdminEditDto
{
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required decimal MonthlySalary { get; set; }
    public required string Address { get; set; }
}
