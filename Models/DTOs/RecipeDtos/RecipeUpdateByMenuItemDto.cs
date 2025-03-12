using System;

namespace CoffeeHub.Models.DTOs.RecipeDtos;

public class RecipeUpdateByMenuItemDto
{
    public Guid MenuItemId { get; set; }
    public List<RecipeIngredientEditDto> Recipes { get; set; } = new List<RecipeIngredientEditDto>();
}
