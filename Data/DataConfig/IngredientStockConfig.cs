using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Models.Domains;

public class IngredientStockConfig : IEntityTypeConfiguration<IngredientStock>
{
    public void Configure(EntityTypeBuilder<IngredientStock> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.IngredientId)
            .IsRequired();

        builder.Property(e => e.Quantity)
            .IsRequired();
        
        builder.Property(e => e.UnitOfMeasurement)
            .IsRequired();

        builder.Property(e => e.ExpiryDate)
            .IsRequired();

        builder.Property(e => e.CostPrice)
            .IsRequired();

        builder.Property(e => e.RemainingStock)
            .IsRequired();

        builder.Property(e => e.PurchaseDate)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(e => e.Ingredient)
            .WithMany(e => e.IngredientStocks)
            .HasForeignKey(e => e.IngredientId);
    }
}

