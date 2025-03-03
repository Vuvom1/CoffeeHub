using System;

namespace CoffeeHub.Models;

public class MenuItem : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public long CategoryId { get; set; }
    // public virtual Category Category { get; set; } = null!;
}
