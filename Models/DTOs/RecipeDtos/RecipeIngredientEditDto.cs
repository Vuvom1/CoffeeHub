using System;

namespace CoffeeHub.Models.DTOs.RecipeDtos;

public class RecipeIngredientEditDto
{
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
}
