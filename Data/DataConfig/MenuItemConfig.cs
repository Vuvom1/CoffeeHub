using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.BarCode)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(d => d.MenuItemCategory)
            .WithMany(p => p.MenuItems)
            .HasForeignKey(d => d.MenuItemCategoryId);
    }
}
