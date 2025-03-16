using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Delivery : BaseEntity
{
    public required Guid OrderId { get; set; }
    public required string ReceiverName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required DateTime Date { get; set; }
    public required OrderStatus Status { get; set; }
    public string? Note { get; set; }
    public virtual Order? Order { get; set; } 
}
