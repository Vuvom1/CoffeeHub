using System;

namespace CoffeeHub.Models.DTOs.IngredientExportOrderDtos;

public class AddIngredientExportOrderDto
{
    public required Guid IngredientStockId { get; set; }
    public required decimal Quantity { get; set; }
    public string? ExportReason { get; set; }
    public DateTime ExportDate { get; set; } = DateTime.UtcNow;
}
