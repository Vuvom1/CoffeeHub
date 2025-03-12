using System;

namespace CoffeeHub.Models.DTOs.RecipeDtos;

public class RecipeAddDto
{
    public Guid MenuItemId { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
}
