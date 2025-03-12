using System;

namespace CoffeeHub.Models.DTOs.RecipeDtos;


public class RecipeDto
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    
}
