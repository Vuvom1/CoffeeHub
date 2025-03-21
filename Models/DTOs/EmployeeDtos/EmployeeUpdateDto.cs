using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.EmployeeDtos;

public class EmployeeUpdateDto
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal? MonthlySalary { get; set; }
    public string? Address { get; set; }
    public EmployeeRole Role { get; set; }
    public required DateTime DateStartWork { get; set; }

}
