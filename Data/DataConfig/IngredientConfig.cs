using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.UnitOfMeasurement)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.TotalQuantity)
            .HasDefaultValue("0")
            .HasMaxLength(50);

        builder.HasOne(i => i.IngredientCategory)
            .WithMany(ic => ic.Ingredients)
            .HasForeignKey(i => i.IngredientCategoryId);
    }
}
