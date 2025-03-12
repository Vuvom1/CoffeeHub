using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.Domains
{
    public class OrderDetail : BaseEntity
    {
        public Guid MenuItemId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}
