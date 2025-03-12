using System;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class AuthDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public Guid? EmployeeId { get; set; }
}
