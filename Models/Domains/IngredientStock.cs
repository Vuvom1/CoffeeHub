using System;

namespace CoffeeHub.Models.Domains;

public class IngredientStock : BaseEntity
{
    public long? IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public string UnitOfMeasurement { get; set; } = null!;
    public decimal CostPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public decimal RemainingStock { get; set; }
    public virtual Ingredient Ingredient { get; set; } = null!;

    public IngredientStock()
    {
        RemainingStock = Quantity;
        PurchaseDate = DateTime.Now;
    }
}
