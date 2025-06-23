using System;
using Microsoft.EntityFrameworkCore;
using CoffeeHub.Enums;
using CoffeeHub.Data.DataConfig;
using CoffeeHub.Models.Domains;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoffeeHub.Models;

public class CoffeeHubContext : IdentityDbContext<IdentityUser, IdentityRole, string>
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
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<TableBooking> TableBookings { get; set; }
    public DbSet<MenuItemHistory> MenuItemHistories { get; set; }
    public DbSet<IngredientExportOrder> IngredientExportOrders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

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
        modelBuilder.ApplyConfiguration(new DeliveryConfig());
        modelBuilder.ApplyConfiguration(new TableConfiguration());
        modelBuilder.ApplyConfiguration(new TableBookingConfiguration());
        modelBuilder.ApplyConfiguration(new MenuIItemHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientExportOrderConfig());

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        Guid employeeId = new("00000000-0000-0000-0000-000000000001");
        Guid guestId = new("00000000-0000-0000-0000-000000000002");
        Guid adminId = new("00000000-0000-0000-0000-000000000003");
        Guid adminAuthId = new("00000000-0000-0000-0000-000000000004");
        Guid employeeAuthId = new("00000000-0000-0000-0000-000000000005");
        Guid guestAuthId = new("00000000-0000-0000-0000-000000000006");

        modelBuilder.Entity<Auth>().HasData(
            new Auth
            {
            Id = adminAuthId,
            Username = "admin",
            PasswordHash = Convert.FromHexString("F3DEAF58D30CF6E08E8D5FEA55CB026378B7F9F6FC816E30110C86219F94CCC2A24A09219BD28782945804056CFA165154D22F69042FD8D020E56F2F001CF201"),
            PasswordSalt = Convert.FromHexString("E960C521B61E478EE05FC509CE23931FDB659097A71C5CA30184E4C6A046F297C6508F7A4206003EAB907E46EA5C8CC6C073DA1680E5A6B47C7667FE3E013DAC216D01FE5BF9BA32FCBCE7E4CE1861EAA7897B7FBC505916B85ACB09574F8D474B4A62F377DD079D0BC56C96ABF675AA4B1D05DC865D57D9626EF5E797C99DE0"),
            Role = UserRole.Admin,
            Email = "admin@gmail.com"
            },

            new Auth
            {
            Id = employeeAuthId,
            Username = "system",  
            PasswordHash = Convert.FromHexString("F3DEAF58D30CF6E08E8D5FEA55CB026378B7F9F6FC816E30110C86219F94CCC2A24A09219BD28782945804056CFA165154D22F69042FD8D020E56F2F001CF201"),
            PasswordSalt = Convert.FromHexString("E960C521B61E478EE05FC509CE23931FDB659097A71C5CA30184E4C6A046F297C6508F7A4206003EAB907E46EA5C8CC6C073DA1680E5A6B47C7667FE3E013DAC216D01FE5BF9BA32FCBCE7E4CE1861EAA7897B7FBC505916B85ACB09574F8D474B4A62F377DD079D0BC56C96ABF675AA4B1D05DC865D57D9626EF5E797C99DE0"),
            Role = UserRole.Employee,
            Email = ""
            },

            new Auth
            {
            Id = guestAuthId,
            Username = "guest",     
            PasswordHash = Convert.FromHexString("F3DEAF58D30CF6E08E8D5FEA55CB026378B7F9F6FC816E30110C86219F94CCC2A24A09219BD28782945804056CFA165154D22F69042FD8D020E56F2F001CF201"),
            PasswordSalt = Convert.FromHexString("E960C521B61E478EE05FC509CE23931FDB659097A71C5CA30184E4C6A046F297C6508F7A4206003EAB907E46EA5C8CC6C073DA1680E5A6B47C7667FE3E013DAC216D01FE5BF9BA32FCBCE7E4CE1861EAA7897B7FBC505916B85ACB09574F8D474B4A62F377DD079D0BC56C96ABF675AA4B1D05DC865D57D9626EF5E797C99DE0"),
            Role = UserRole.Customer,
            Email = ""
            }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = employeeId,
                Name = "Online System",
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "0000000000", 
                MonthlySalary = 0,
                Address = "Ho Chi Minh City",
                AuthId = employeeAuthId,
                Role = EmployeeRole.Cashier,
                DateStartWork = new DateTime(2020, 1, 1)
            }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = guestId,
                Name = "Guest",
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "0000000000",
                Address = "Ho Chi Minh City",
                AuthId = guestAuthId,
                IsAvailable = true,
            }
        );

        modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = adminId,
                Name = "Admin",
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "0000000000",
                Address = "Ho Chi Minh City",
                AuthId = adminAuthId
            }
        );

        modelBuilder.Entity<Shift>().HasData(
            new Shift
            {
            Id = Guid.NewGuid(),
            Name = "Morning Shift",
            StartTime = new TimeSpan(6, 0, 0),
            EndTime = new TimeSpan(12, 0, 0)
            },
            new Shift
            {
            Id = Guid.NewGuid(),
            Name = "Afternoon Shift",
            StartTime = new TimeSpan(12, 0, 0),
            EndTime = new TimeSpan(18, 0, 0)
            },
            new Shift
            {
            Id = Guid.NewGuid(),
            Name = "Evening Shift",
            StartTime = new TimeSpan(18, 0, 0),
            EndTime = new TimeSpan(22, 0, 0)
            }
        );
    }
}
