using System;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class RegisterDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}
