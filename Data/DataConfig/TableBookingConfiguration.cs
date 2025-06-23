using System;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class TableBookingConfiguration : IEntityTypeConfiguration<TableBooking>
{
    public void Configure(EntityTypeBuilder<TableBooking> builder)
    {
        builder.ToTable("TableBookings");

        builder.HasKey(tb => tb.Id);

        builder.Property(tb => tb.BookingDate)
            .IsRequired();

        builder.Property(tb => tb.Duration)
            .IsRequired();

        builder.Property(tb => tb.Status)
            .IsRequired();

        builder.HasOne(tb => tb.Table)
            .WithMany(t => t.TableBookings)
            .HasForeignKey(tb => tb.TableId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
