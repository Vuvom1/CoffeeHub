using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.Models;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
