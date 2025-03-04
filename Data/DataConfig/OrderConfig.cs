using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        
            builder.ToTable("Orders");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.OrderDate)
                .IsRequired()
                .HasColumnName("OrderDate");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("Status");

            builder.Property(e => e.TotalQuantity)
                .IsRequired()
                .HasColumnName("TotalQuantity");

            builder.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeId");

            builder.Property(e => e.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId);

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId);
    }
}
