using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.OrderDtos;

namespace CoffeeHub.Models.DTOs.DeliveryDtos;

public class DeliveryDto
{
    public required Guid OrderId { get; set; }
    public required string ReceiverName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required DateTime Date { get; set; }
    public required OrderStatus Status { get; set; }
    public string? Note { get; set; }
   public required virtual OrderDto Order { get; set; } 
}
