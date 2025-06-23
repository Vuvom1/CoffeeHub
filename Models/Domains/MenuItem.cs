using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.Domains
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? BarCode { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public Guid MenuItemCategoryId { get; set; }
        public virtual MenuItemCategory MenuItemCategory { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
        public virtual ICollection<MenuItemHistory> MenuItemHistories { get; set; } = new HashSet<MenuItemHistory>();   
    }
}

