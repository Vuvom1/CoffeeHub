using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.OrderDetailDtos;

namespace CoffeeHub.Models.DTOs.OrderDtos;

public class OrderAddDto
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus? Status { get; set; } = OrderStatus.Pending;
    public Guid? EmployeeId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public Guid? CustomerId { get; set; } = null;
    public string? Note { get; set; } = null;
    public Guid? PromotionId { get; set; } = null;
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public required int OrderCardNumber { get; set; }
    public ICollection<OrderDetailAddDto> OrderDetails { get; set; } = [];
    public DeliveryAddDto? Delivery { get; set; } = null;
}
