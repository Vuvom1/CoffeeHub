using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.PromtionDtos;

public class PromotionDto
{   
    public long Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PromotionType PromotionType { get; set; }
    public decimal DiscountValue { get; set; } = 0;
    public decimal MinPurchaseAmount { get; set; }
    public decimal MaxDiscountAmount { get; set; }
    public int? UssageLimit { get; set; }
    public int? UssageCount { get; set; } = 0;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; } = true;
}
