using System;

namespace CoffeeHub.Models.Domains;

public class IngredientStock : BaseEntity
{
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime DateOfManufacture { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual Ingredient Ingredient { get; set; } = null!;
}
