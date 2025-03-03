using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models;

public class OrderDetail : BaseEntity
{
    public long OrderId { get; set; }
    public long MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public virtual Order Order { get; set; } = null!;
    public virtual MenuItem MenuItem { get; set; } = null!;
}
