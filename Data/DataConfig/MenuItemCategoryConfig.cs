using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class MenuItemCategoryConfig : IEntityTypeConfiguration<MenuItemCategory>
{
    public void Configure(EntityTypeBuilder<MenuItemCategory> builder)
    {
        builder.ToTable("MenuItemCategories");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(e => e.MenuItems)
            .WithOne(e => e.MenuItemCategory)
            .HasForeignKey(e => e.MenuItemCategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
