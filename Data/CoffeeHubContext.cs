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
        modelBuilder.ApplyConfiguration(new RecipeConfig());
        modelBuilder.ApplyConfiguration(new IngredientConfig());
        modelBuilder.ApplyConfiguration(new IngredientStockConfig());
        modelBuilder.ApplyConfiguration(new IngredientCategoryConfig());

        // modelBuilder.Entity<Auth>().Property(e => e.Role).HasConversion<int>();

        //  // Enforce uniqueness on foreign key properties
        // modelBuilder.Entity<Auth>()
        //     .HasIndex(a => a.AdminId)
        //     .IsUnique()
        //     .HasFilter("[AdminId] IS NOT NULL");

        // modelBuilder.Entity<Auth>()
        //     .HasIndex(a => a.EmployeeId)
        //     .IsUnique()
        //     .HasFilter("[EmployeeId] IS NOT NULL");

        // modelBuilder.Entity<Auth>()
        //     .HasIndex(a => a.CustomerId)
        //     .IsUnique()
        //     .HasFilter("[CustomerId] IS NOT NULL");

    }
}
