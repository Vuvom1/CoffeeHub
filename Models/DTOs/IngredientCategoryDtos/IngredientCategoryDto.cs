using System;

namespace CoffeeHub.Models.DTOs.IngredientCategoryDtos;

public class IngredientCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
