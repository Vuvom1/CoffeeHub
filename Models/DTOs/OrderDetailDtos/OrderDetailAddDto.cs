using System;

namespace CoffeeHub.Models.DTOs.OrderDetailDtos;

public class OrderDetailAddDto
{
    public Guid MenuItemId { get; set; }
    public int Quantity { get; set; }
}
