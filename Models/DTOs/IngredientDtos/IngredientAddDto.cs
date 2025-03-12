using System;

namespace CoffeeHub.Models.DTOs.IngredientDtos;

public class IngredientAddDto
{
    public required string  Name { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = null!;
    public required Guid IngredientCategoryId { get; set; }
} 