using System;
using CoffeeHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(od => od.Id);

        builder.Property(od => od.Quantity)
            .IsRequired();

        builder.Property(od => od.Price)
            .IsRequired()
            .HasColumnType("decimal(5, 2)");

        builder.HasOne(od => od.MenuItem)
            .WithMany(mi => mi.OrderDetails)
            .HasForeignKey(od => od.MenuItemId);

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
    }
}


