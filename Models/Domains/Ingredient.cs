using System;

namespace CoffeeHub.Models.Domains;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = null!;
    public long? IngredientCategoryId { get; set; }
    public virtual IngredientCategory IngredientCategory { get; set; } = null!;
    public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    public virtual ICollection<IngredientStock> IngredientStocks { get; set; } = new HashSet<IngredientStock>();
}
