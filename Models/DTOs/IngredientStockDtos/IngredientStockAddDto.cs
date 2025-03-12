using System;

namespace CoffeeHub.Models.DTOs.IngredientStockDtos;

public class IngredientStockAddDto
{
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public DateTime DateOfManufacture { get; set; }
    public DateTime ExpiryDate { get; set; }
}
