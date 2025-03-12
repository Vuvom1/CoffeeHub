using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class AuthAddDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public bool? IsAvailable { get; set; } = true;
    public required UserRole Role { get; set; }
}
