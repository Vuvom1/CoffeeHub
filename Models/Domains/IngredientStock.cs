using System;

namespace CoffeeHub.Models.Domains;

public class IngredientStock : BaseEntity
{
    public long? IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public string UnitOfMeasurement { get; set; } = null!;
    public decimal CostPrice { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public int RemainingStock { get; set; }
    public virtual Ingredient Ingredient { get; set; } = null!;
}
