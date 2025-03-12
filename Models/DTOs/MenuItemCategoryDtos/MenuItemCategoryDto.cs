using System;

namespace CoffeeHub.Models.DTOs.MenuItemCategoryDtos;

public class MenuItemCategoryDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
