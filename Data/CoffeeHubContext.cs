using System;
using Microsoft.EntityFrameworkCore;
using CoffeeHub.Enums;
using CoffeeHub.Data.DataConfig;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models;

public class CoffeeHubContext : DbContext
{
    public CoffeeHubContext(DbContextOptions<CoffeeHubContext> options) : base(options)
    {
    }

    public DbSet<Auth> Auths { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }  
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuItemCategory> MenuItemCategories { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientStock> IngredientStocks { get; set; }    
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new AuthConfig());
        modelBuilder.ApplyConfiguration(new AdminConfig());
        modelBuilder.ApplyConfiguration(new EmployeeConfig());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new PromotionConfig());
        modelBuilder.ApplyConfiguration(new MenuItemConfig());
        modelBuilder.ApplyConfiguration(new MenuItemCategoryConfig());
        modelBuilder.ApplyConfiguration(new ScheduleConfig());
        modelBuilder.ApplyConfiguration(new ShiftConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderDetailConfig());
        modelBuilder.ApplyConfiguration(new InvoiceConfig());
        modelBuilder.ApplyConfiguration(new RecipeConfig());
        modelBuilder.ApplyConfiguration(new IngredientConfig());
        modelBuilder.ApplyConfiguration(new IngredientStockConfig());
        modelBuilder.ApplyConfiguration(new IngredientCategoryConfig());
        

        modelBuilder.Entity<Auth>().Property(e => e.Role).HasConversion<int>();

         // Enforce uniqueness on foreign key properties
        modelBuilder.Entity<Auth>()
            .HasIndex(a => a.AdminId)
            .IsUnique()
            .HasFilter("[AdminId] IS NOT NULL");

        modelBuilder.Entity<Auth>()
            .HasIndex(a => a.EmployeeId)
            .IsUnique()
            .HasFilter("[EmployeeId] IS NOT NULL");

        modelBuilder.Entity<Auth>()
            .HasIndex(a => a.CustomerId)
            .IsUnique()
            .HasFilter("[CustomerId] IS NOT NULL");

        // Seed Auth entity
        modelBuilder.Entity<Auth>().HasData(
            new Auth
            {
                Id = 1,
                Username = "admin",
                Email = "admin@gmail.com",
                PasswordHash = new byte[] { 0x05, 0x73, 0x40, 0x9E, 0x13, 0x20, 0xAF, 0xC6, 0xB6, 0xF9, 0xC3, 0x71, 0x70, 0x29, 0xAC, 0xE9, 0x1E, 0x5F, 0x90, 0xE3, 0x5C, 0x9B, 0x97, 0xF6, 0x3B, 0x5E, 0xE1, 0x59, 0x21, 0x48, 0x3E, 0x43, 0xA7, 0x73, 0x7E, 0x6D, 0x74, 0x96, 0x03, 0x86, 0x60, 0xB3, 0x56, 0x1F, 0x5D, 0x8E, 0x36, 0xE6, 0x46, 0x2D, 0xD3, 0x1E, 0x32, 0xFA, 0x4A, 0x30, 0x0C, 0x2B, 0xE4, 0xC0, 0x0F, 0xAC, 0x41, 0xE2 },
                PasswordSalt = new byte[] { 0xCA, 0x6F, 0x39, 0xA9, 0x70, 0x6B, 0x8C, 0xCC, 0xBB, 0x66, 0xE6, 0x66, 0x92, 0x4A, 0xCA, 0xCF, 0x5E, 0x93, 0x41, 0x7A, 0x44, 0x38, 0x28, 0x13, 0x75, 0x21, 0xC8, 0x8A, 0xE1, 0xC6, 0x69, 0xE0, 0xF9, 0x73, 0xD8, 0xDC, 0x24, 0x30, 0x4B, 0x47, 0xFA, 0xAC, 0xF1, 0xC9, 0xE2, 0x03, 0x40, 0xA3, 0x0D, 0x13, 0x85, 0x99, 0xA5, 0x70, 0x2A, 0x5B, 0x8C, 0x72, 0xD3, 0x81, 0x57, 0x3E, 0xB5, 0xD0, 0x1A, 0x86, 0x82, 0x13, 0x4E, 0x5A, 0x9C, 0x3F, 0x38, 0xE3, 0xA6, 0x3F, 0x5E, 0x05, 0xD2, 0xCF, 0x04, 0x81, 0xB1, 0x03, 0x60, 0xEA, 0xA9, 0x3C, 0x43, 0xD6, 0xA0, 0x65, 0x16, 0x80, 0x5D, 0x6C, 0xE4, 0xC8, 0xCC, 0x3A, 0x23, 0x46, 0x74, 0x4E, 0x9D, 0x41, 0x2F, 0x70, 0x56, 0xDE, 0xB3, 0x0A, 0x5C, 0xE8, 0x1F, 0x00, 0xA3, 0x45, 0xA6, 0xE7, 0xE6, 0x28, 0xD5, 0x5D, 0x06, 0x2B, 0xCB, 0xA9 },
                CreatedAt = new DateTime(2025, 3, 2), 
                UpdatedAt = new DateTime(2025, 3, 2),
                AdminId = 1,
                IsAvailable = true,
                Role = UserRole.Admin
            }
        );

        // Seed Admin entity
        modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                Name = "Admin",
                DateOfBirth = new DateTime(1990, 3, 2),
                PhoneNumber = "0123456789",
                MonthlySalary = 10000,
                Address = "Hanoi",
                AuthId = 1,
                CreatedAt = new DateTime(2025, 3, 2),
                UpdatedAt = new DateTime(2025, 3, 2),
            }
        );

    }
}
