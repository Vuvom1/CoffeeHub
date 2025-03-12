using System;

namespace CoffeeHub.Models.DTOs.RecipeDtos;

public class RecipeIngredientDto
{
    public Guid MenuItemId { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
}
