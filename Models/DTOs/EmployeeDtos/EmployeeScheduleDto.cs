using System;
using CoffeeHub.Models.DTOs.ScheduleDtos;

namespace CoffeeHub.Models.DTOs.EmployeeDtos;

public class EmployeeScheduleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public decimal MonthlySalary { get; set; }
    public string Address { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime DateStartWork { get; set; }
    public Guid AuthId { get; set; }
    public ICollection<ScheduleDto> Schedules { get; set; } = [];
}
