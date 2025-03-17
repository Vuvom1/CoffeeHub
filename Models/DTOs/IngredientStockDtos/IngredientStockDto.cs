using System;
using CoffeeHub.Models.DTOs.IngredientDtos;

namespace CoffeeHub.Models.DTOs.IngredientStockDtos;

public class IngredientStockDto
{
    public Guid Id { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public decimal TotalCostPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime DateOfManufacture { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual IngredientDto Ingredient { get; set; } = null!;
}
