using System;

namespace CoffeeHub.Models.Domains;

public class IngredientExportOrder : BaseEntity
{
    public required Guid IngredientStockId { get; set; }
    public IngredientStock? IngredientStock { get; set; }
    public required decimal Quantity { get; set; }
    public string? ExportReason { get; set; }
    public DateTime ExportDate { get; set; } = DateTime.UtcNow;
}
