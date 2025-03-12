using System;

namespace CoffeeHub.Models.Domains;

public class Recipe : BaseEntity
{
    public Guid MenuItemId { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public virtual Ingredient Ingredient { get; set; } = null!;
    public virtual MenuItem MenuItem { get; set; } = null!;
}
