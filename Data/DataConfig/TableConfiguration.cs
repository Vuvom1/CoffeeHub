using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable("Tables");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Number)
            .IsRequired();

        builder.Property(t => t.Capacity)
            .IsRequired();

        builder.Property(t => t.Status)
            .IsRequired();

        builder.HasMany(t => t.TableBookings)
            .WithOne(tb => tb.Table)
            .HasForeignKey(tb => tb.TableId)
            .OnDelete(DeleteBehavior.Cascade);
            
    }
}
