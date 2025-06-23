using System;
using CoffeeHub.Models.DTOs.IngredientStockDtos;

namespace CoffeeHub.Models.DTOs.IngredientExportOrderDtos;

public class IngredientExportOrderDto
{
    public Guid Id { get; set; }
    public required Guid IngredientStockId { get; set; }
    public IngredientStockDto? IngredientStock { get; set; }
    public required decimal Quantity { get; set; }
    public string? ExportReason { get; set; }
    public DateTime ExportDate { get; set; } = DateTime.UtcNow;
}
