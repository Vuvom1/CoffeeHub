using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.CustomerDtos;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class RegisterCustomerDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public bool IsAvailable { get; set; } = true;
    public UserRole? Role { get; set; } = UserRole.Customer;
    public virtual required CustomerAddDto Customer { get; set; }
}
