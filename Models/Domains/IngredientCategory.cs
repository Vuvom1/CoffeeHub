using System;

namespace CoffeeHub.Models.Domains;

public class IngredientCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
}
