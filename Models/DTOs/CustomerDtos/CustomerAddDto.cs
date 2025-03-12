using System;
using CoffeeHub.Models.DTOs.AuthDtos;

namespace CoffeeHub.Models.DTOs.CustomerDtos;

public class CustomerAddDto
{
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public bool? IsAvailable { get; set; } = true;
    public int? Point { get; set; } = 0;
    public Guid AuthId { get; set; }
}
