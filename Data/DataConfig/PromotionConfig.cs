using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class PromotionConfig : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasMaxLength(200);

        builder.Property(p => p.DiscountValue)
            .IsRequired()
            .HasColumnType("decimal(5, 2)");

        builder.Property(p => p.StartDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(p => p.EndDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(p => p.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasMany(p => p.Invoices)
            .WithOne(i => i.Promotion)
            .HasForeignKey(i => i.PromotionId);
    }
}
