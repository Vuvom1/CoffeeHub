﻿// <auto-generated />
using System;
using CoffeeHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeHub.Migrations
{
    [DbContext(typeof(CoffeeHubContext))]
    [Migration("20250302172621_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoffeeHub.Models.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MonthlySalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Hanoi",
                            AuthId = 1L,
                            CreatedAt = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MonthlySalary = 10000m,
                            Name = "Admin",
                            PhoneNumber = "0123456789",
                            UpdatedAt = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CoffeeHub.Models.Auth", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AdminId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique()
                        .HasFilter("[AdminId] IS NOT NULL");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.ToTable("Auths");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            IsAvailable = true,
                            PasswordHash = new byte[] { 5, 115, 64, 158, 19, 32, 175, 198, 182, 249, 195, 113, 112, 41, 172, 233, 30, 95, 144, 227, 92, 155, 151, 246, 59, 94, 225, 89, 33, 72, 62, 67, 167, 115, 126, 109, 116, 150, 3, 134, 96, 179, 86, 31, 93, 142, 54, 230, 70, 45, 211, 30, 50, 250, 74, 48, 12, 43, 228, 192, 15, 172, 65, 226 },
                            PasswordSalt = new byte[] { 202, 111, 57, 169, 112, 107, 140, 204, 187, 102, 230, 102, 146, 74, 202, 207, 94, 147, 65, 122, 68, 56, 40, 19, 117, 33, 200, 138, 225, 198, 105, 224, 249, 115, 216, 220, 36, 48, 75, 71, 250, 172, 241, 201, 226, 3, 64, 163, 13, 19, 133, 153, 165, 112, 42, 91, 140, 114, 211, 129, 87, 62, 181, 208, 26, 134, 130, 19, 78, 90, 156, 63, 56, 227, 166, 63, 94, 5, 210, 207, 4, 129, 177, 3, 96, 234, 169, 60, 67, 214, 160, 101, 22, 128, 93, 108, 228, 200, 204, 58, 35, 70, 116, 78, 157, 65, 47, 112, 86, 222, 179, 10, 92, 232, 31, 0, 163, 69, 166, 231, 230, 40, 213, 93, 6, 43, 203, 169 },
                            Role = 0,
                            UpdatedAt = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("CoffeeHub.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsAvailable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CoffeeHub.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStartWork")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MonthlySalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CoffeeHub.Models.Auth", b =>
                {
                    b.HasOne("CoffeeHub.Models.Admin", "Admin")
                        .WithOne("Auth")
                        .HasForeignKey("CoffeeHub.Models.Auth", "AdminId");

                    b.HasOne("CoffeeHub.Models.Customer", "Customer")
                        .WithOne("Auth")
                        .HasForeignKey("CoffeeHub.Models.Auth", "CustomerId");

                    b.HasOne("CoffeeHub.Models.Employee", "Employee")
                        .WithOne("Auth")
                        .HasForeignKey("CoffeeHub.Models.Auth", "EmployeeId");

                    b.Navigation("Admin");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CoffeeHub.Models.Admin", b =>
                {
                    b.Navigation("Auth")
                        .IsRequired();
                });

            modelBuilder.Entity("CoffeeHub.Models.Customer", b =>
                {
                    b.Navigation("Auth")
                        .IsRequired();
                });

            modelBuilder.Entity("CoffeeHub.Models.Employee", b =>
                {
                    b.Navigation("Auth")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
