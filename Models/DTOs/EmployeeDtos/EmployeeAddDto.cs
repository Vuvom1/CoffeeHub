using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.AuthDtos;

namespace CoffeeHub.Models.DTOs.EmployeeDtos;

public class EmployeeAddDto
{
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public decimal MonthlySalary { get; set; }
    public required string Address { get; set; }
    public EmployeeRole Role { get; set; }
    public DateTime? DateStartWork { get; set; } = DateTime.Now;
    public Guid AuthId { get; set; }
}
