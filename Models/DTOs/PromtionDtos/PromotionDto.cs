using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.PromtionDtos;

public class PromotionDto
{   
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal DiscountRate { get; set; } = 0;
    public required decimal MinPurchaseAmount { get; set; }
    public required decimal MaxDiscountAmount { get; set; }
    public int? UssageLimit { get; set; }
    public int? UssageCount { get; set; }
    public CustomerLevel CustomerLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
}
