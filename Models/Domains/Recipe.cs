using System;

namespace CoffeeHub.Models.Domains;

public class Recipe : BaseEntity
{
    public long? MenuItemId { get; set; }
    public long? IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public string UnitOfMeasurement { get; set; } = null!;
    public virtual Ingredient Ingredient { get; set; } = null!;
    public virtual MenuItem MenuItem { get; set; } = null!;
}
