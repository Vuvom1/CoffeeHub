using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.DTOs.CustomerDtos;

public class CustomerDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required string IsAvailable { get; set; }
    public int Point { get; set; }
    public CustomerLevel CustomerLevel { get; set; }
    public Guid AuthId { get; set; }
    public virtual Auth Auth { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
