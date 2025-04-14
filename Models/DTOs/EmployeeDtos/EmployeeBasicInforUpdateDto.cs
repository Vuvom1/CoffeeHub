using System;

namespace CoffeeHub.Models.DTOs.EmployeeDtos;

public class EmployeeBasicInforUpdateDto
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
