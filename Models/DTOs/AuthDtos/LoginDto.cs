using System;

namespace CoffeeHub.Models.DTOs.AuthDtos;

public class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
