using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.OrderDtos;

namespace CoffeeHub.Models.DTOs.DeliveryDtos;

public class DeliveryAddDto
{
    public Guid? OrderId { get; set; }
    public required string ReceiverName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public DateTime? Date { get; set; } = DateTime.Now;
    public DeliveryStatus? Status { get; set; } = DeliveryStatus.Pending;
    public string? Note { get; set; }
}
