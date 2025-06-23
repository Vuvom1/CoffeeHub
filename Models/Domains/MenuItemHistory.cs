using System;

namespace CoffeeHub.Models.Domains;

public class MenuItemHistory : BaseEntity
{
    public Guid MenuItemId { get; set; }
    public virtual MenuItem MenuItem { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public Guid MenuItemCategoryId { get; set; }
    public virtual MenuItemCategory MenuItemCategory { get; set; } = null!;
}
