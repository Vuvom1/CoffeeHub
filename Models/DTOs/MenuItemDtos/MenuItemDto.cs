using System;

namespace CoffeeHub.Models.DTOs.MenuItem;

public class MenuItemDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int MenuItemCategoryId { get; set; }
    public string MenuItemCategoryName { get; set; } = null!;
    public bool IsActive { get; set; } = true;
}
