using System;
using CoffeeHub.Models.DTOs.AdminDtos;
using CoffeeHub.Models.DTOs.CustomerDtos;
using CoffeeHub.Models.DTOs.EmployeeDtos;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class AuthDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public Guid? EmployeeId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? AdminId { get; set; }
    public virtual EmployeeDto? Employee { get; set; }
    public virtual CustomerDto? Customer { get; set; }
    public virtual AdminDto? Admin { get; set; }
}
