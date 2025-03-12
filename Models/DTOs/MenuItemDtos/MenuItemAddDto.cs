using System;

namespace CoffeeHub.Models.DTOs.MenuItemDtos;

public class MenuItemAddDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public Guid MenuItemCategoryId { get; set; }
    public bool IsActive { get; set; } = true;
}
