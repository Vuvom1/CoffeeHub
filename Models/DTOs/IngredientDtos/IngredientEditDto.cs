using System;

namespace CoffeeHub.Models.DTOs.IngredientDtos;

public class IngredientEditDto
{
    public required string Name { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = null!;
    public decimal ThresholdQuantity { get; set; }
    public required Guid IngredientCategoryId { get; set; }
}
