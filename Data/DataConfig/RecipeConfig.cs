using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class RecipeConfig : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IngredientId)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.UnitOfMeasurement)
            .IsRequired();

        builder.Property(x => x.MenuItemId)
            .IsRequired();

        builder.HasOne(x => x.MenuItem) 
            .WithMany(x => x.Recipes)
            .HasForeignKey(x => x.MenuItemId);

        builder.HasOne(x => x.Ingredient)  
            .WithMany(x => x.Recipes)
            .HasForeignKey(x => x.IngredientId);
    }
}
