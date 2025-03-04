using System;
using CoffeeHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Date)
            .IsRequired();
        
        builder.Property(x => x.ShiftId)
            .IsRequired();

        builder.HasOne(x => x.Shift)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.ShiftId);
    }
}

