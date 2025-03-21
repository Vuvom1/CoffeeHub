using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.DTOs.OrderDtos;

public class OrderDto
{
    public Guid Id { get; set; }
     public DateTime OrderDate { get; set; } = DateTime.Now;
    public required int TotalQuantity { get; set; }
    public required OrderStatus Status { get; set; }
    public required PaymentMethod PaymentMethod { get; set; }
    public required decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public required Guid EmployeeId { get; set; }
    public Guid? CustomerId { get; set; }
    public string? Note { get; set; }
    public Guid? PromotionId { get; set; }
    public required int OrderCardNumber { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } = new HashSet<OrderDetailDto>();
    public virtual Promotion? Promotion { get; set; } = null!;
    public virtual Delivery? Delivery { get; set; }
}
