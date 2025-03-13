using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.OrderDetailDtos;

namespace CoffeeHub.Models.DTOs.OrderDtos;

public class OrderAddDto
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus? Status { get; set; } = OrderStatus.Pending;
    public required Guid EmployeeId { get; set; }
    public Guid? CustomerId { get; set; } = null;
    public string? Note { get; set; }
    public Guid? PromotionId { get; set; } = null;
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public required int OrderCardNumber { get; set; }
    public ICollection<OrderDetailAddDto> OrderDetails { get; set; } = [];
}
