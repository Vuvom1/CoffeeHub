using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class AdminConfig : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
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
            .HasAnnotation("RegularExpression", @"^(\+84|0)\d{9,10}$");

        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.AuthId)
            .IsRequired();

        builder.HasOne(x => x.Auth)
            .WithOne(x => x.Admin)
            .HasForeignKey<Auth>(x => x.AdminId);
    }

}
