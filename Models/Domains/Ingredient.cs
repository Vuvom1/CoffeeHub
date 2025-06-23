using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    public decimal TotalQuantity { get; set; }
    public decimal ThresholdQuantity { get; set; }
    public Guid IngredientCategoryId { get; set; }
    public virtual IngredientCategory IngredientCategory { get; set; } = null!;
    public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    public virtual ICollection<IngredientStock> IngredientStocks { get; set; } = new HashSet<IngredientStock>();
}
