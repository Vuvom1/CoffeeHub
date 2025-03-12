using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.Domains;

public class Promotion : BaseEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal DiscountRate { get; set; } = 0;
    public decimal MinPurchaseAmount { get; set; }
    public decimal MaxDiscountAmount { get; set; }
    public required int UssageLimit { get; set; }
    public int? UssageCount { get; set; } = 0;
    public CustomerLevel CustomerLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
}
