using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Invoice : BaseEntity
{
    public long OrderId { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public long? PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; } = null!;
    public virtual Order Order { get; set; } = null!;
   
}
