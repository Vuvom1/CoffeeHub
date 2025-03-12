using System;

namespace CoffeeHub.Models.DTOs.IngredientDtos;

public class IngredientCategoryEditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
