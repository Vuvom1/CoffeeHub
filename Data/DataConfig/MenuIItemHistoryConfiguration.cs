using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class MenuIItemHistoryConfiguration : IEntityTypeConfiguration<MenuItemHistory>
{
    public void Configure(EntityTypeBuilder<MenuItemHistory> builder)
    {
        builder.ToTable("MenuItemHistories");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Price)
            .IsRequired();

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.ImageUrl)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.IsAvailable)
            .IsRequired();

        builder.HasOne(m => m.MenuItem)
            .WithMany(m => m.MenuItemHistories)
            .HasForeignKey(m => m.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
