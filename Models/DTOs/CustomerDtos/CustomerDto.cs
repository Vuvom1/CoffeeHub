using System;

namespace CoffeeHub.Models.DTOs.CustomerDtos;

public class CustomerDto
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }   
    public string? IsAvailable { get; set; }
    public string? Role { get; set; }
    public int Point { get; set; } = 0;
    public Guid? AuthId { get; set; }
}
