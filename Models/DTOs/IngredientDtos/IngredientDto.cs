using System;

namespace CoffeeHub.Models.DTOs.IngredientDtos;

public class IngredientDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = null!;
    public string TotalQuantity { get; set; } = null!;
    public required Guid IngredientCategoryId { get; set; }
    public string IngredientCategoryName { get; set; } = null!;
}
