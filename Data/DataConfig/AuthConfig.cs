using System;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeHub.Data.DataConfig;

public class AuthConfig : IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
            
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.Property(x => x.PasswordSalt)
            .IsRequired();

        builder.Property(x => x.IsAvailable)
            .HasDefaultValue(true);

        builder.Property(x => x.Role)
            .HasDefaultValue(UserRole.Customer);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50)
            .HasAnnotation("RegularExpression", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Auth)
            .HasForeignKey<Customer>(x => x.AuthId);

        builder.HasOne(x => x.Admin)
            .WithOne(x => x.Auth)
            .HasForeignKey<Admin>(x => x.AuthId);
        
        builder.HasOne(x => x.Employee)
            .WithOne(x => x.Auth)
            .HasForeignKey<Employee>(x => x.AuthId);
    }
}
