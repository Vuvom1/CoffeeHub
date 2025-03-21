using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15)
            .HasAnnotation("RegularExpression", @"^0[0-9]{9}$");

        builder.Property(x => x.MonthlySalary)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Role)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.DateStartWork)
            .IsRequired()
            .HasColumnType("date");

        builder.HasOne(x => x.Auth)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.AuthId);


        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);    
 
    }
    
}
