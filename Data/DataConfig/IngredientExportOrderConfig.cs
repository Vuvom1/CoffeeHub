using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class IngredientExportOrderConfig : IEntityTypeConfiguration<IngredientExportOrder>
{
    public void Configure(EntityTypeBuilder<IngredientExportOrder> builder)
    {
        builder.ToTable("IngredientExportOrders");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.IngredientStockId).IsRequired();
        builder.Property(e => e.Quantity).IsRequired();
        builder.Property(e => e.ExportReason).HasMaxLength(500);
        builder.Property(e => e.ExportDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(e => e.IngredientStock)
            .WithMany()
            .HasForeignKey(e => e.IngredientStockId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
