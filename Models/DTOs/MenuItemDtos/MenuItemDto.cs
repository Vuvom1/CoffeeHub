using System;

namespace CoffeeHub.Models.DTOs.MenuItem;

public class MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? BarCode { get; set; } = null;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public Guid MenuItemCategoryId { get; set; }
    public string MenuItemCategoryName { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
}
