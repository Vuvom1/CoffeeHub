using System;
using CoffeeHub.Models.DTOs.MenuItem;

namespace CoffeeHub.Models.DTOs.OrderDtos;

public class OrderDetailDto
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public virtual required MenuItemDto MenuItem { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    
}
