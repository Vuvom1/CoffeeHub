using System;

namespace CoffeeHub.Models.Domains;

public class MenuItemCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
}
