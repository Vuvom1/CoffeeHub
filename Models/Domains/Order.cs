using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Order : BaseEntity
{
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
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public virtual Promotion? Promotion { get; set; } = null!;
}
