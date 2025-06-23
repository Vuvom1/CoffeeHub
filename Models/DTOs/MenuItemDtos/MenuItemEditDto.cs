using System;
using CoffeeHub.Models.DTOs.RecipeDtos;

namespace CoffeeHub.Models.DTOs.MenuItemDtos;

public class MenuItemEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? BarCode { get; set; } = null;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public Guid MenuItemCategoryId { get; set; }
    public bool IsAvailable { get; set; }
    public virtual ICollection<RecipeDto> Recipes { get; set; } = new HashSet<RecipeDto>();
}