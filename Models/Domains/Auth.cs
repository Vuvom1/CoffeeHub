using System;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeHub.Enums;

namespace CoffeeHub.Models;

public class Auth : BaseEntity
{
    public string? Username { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string? Email { get; set; }
    public bool? IsAvailable { get; set; }
    public UserRole? Role { get; set; }
    
    public long? AdminId { get; set; }
    public long? EmployeeId { get; set; }
    public long? CustomerId { get; set; }
    public virtual Admin Admin { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}
