using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Role = table.Column<int>(type: "int", nullable: true, defaultValue: 2),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiscountRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinPurchaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UssageLimit = table.Column<int>(type: "int", nullable: false),
                    UssageCount = table.Column<int>(type: "int", nullable: true),
                    CustomerLevel = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    CustomerLevel = table.Column<int>(type: "int", nullable: false),
                    AuthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DateStartWork = table.Column<DateTime>(type: "date", nullable: false),
                    AuthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UnitOfMeasurement = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TotalQuantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false, defaultValue: 0m),
                    ThresholdQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngredientCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                        column: x => x.IngredientCategoryId,
                        principalTable: "IngredientCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MenuItemCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuItemCategories_MenuItemCategoryId",
                        column: x => x.MenuItemCategoryId,
                        principalTable: "MenuItemCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TableBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeOnly>(type: "time", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableBookings_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderCardNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    DateOfManufacture = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientStocks_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MenuItemCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemHistories_MenuItemCategories_MenuItemCategoryId",
                        column: x => x.MenuItemCategoryId,
                        principalTable: "MenuItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemHistories_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientExportOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientStockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExportReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExportDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientExportOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientExportOrders_IngredientStocks_IngredientStockId",
                        column: x => x.IngredientStockId,
                        principalTable: "IngredientStocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "PasswordSalt", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 5, 16, 12, 33, 36, 765, DateTimeKind.Local).AddTicks(7350), "admin@gmail.com", new byte[] { 243, 222, 175, 88, 211, 12, 246, 224, 142, 141, 95, 234, 85, 203, 2, 99, 120, 183, 249, 246, 252, 129, 110, 48, 17, 12, 134, 33, 159, 148, 204, 194, 162, 74, 9, 33, 155, 210, 135, 130, 148, 88, 4, 5, 108, 250, 22, 81, 84, 210, 47, 105, 4, 47, 216, 208, 32, 229, 111, 47, 0, 28, 242, 1 }, new byte[] { 233, 96, 197, 33, 182, 30, 71, 142, 224, 95, 197, 9, 206, 35, 147, 31, 219, 101, 144, 151, 167, 28, 92, 163, 1, 132, 228, 198, 160, 70, 242, 151, 198, 80, 143, 122, 66, 6, 0, 62, 171, 144, 126, 70, 234, 92, 140, 198, 192, 115, 218, 22, 128, 229, 166, 180, 124, 118, 103, 254, 62, 1, 61, 172, 33, 109, 1, 254, 91, 249, 186, 50, 252, 188, 231, 228, 206, 24, 97, 234, 167, 137, 123, 127, 188, 80, 89, 22, 184, 90, 203, 9, 87, 79, 141, 71, 75, 74, 98, 243, 119, 221, 7, 157, 11, 197, 108, 150, 171, 246, 117, 170, 75, 29, 5, 220, 134, 93, 87, 217, 98, 110, 245, 231, 151, 201, 157, 224 }, 0, new DateTime(2025, 5, 16, 12, 33, 36, 776, DateTimeKind.Local).AddTicks(6540), "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 16, 12, 33, 36, 776, DateTimeKind.Local).AddTicks(7760), "", new byte[] { 243, 222, 175, 88, 211, 12, 246, 224, 142, 141, 95, 234, 85, 203, 2, 99, 120, 183, 249, 246, 252, 129, 110, 48, 17, 12, 134, 33, 159, 148, 204, 194, 162, 74, 9, 33, 155, 210, 135, 130, 148, 88, 4, 5, 108, 250, 22, 81, 84, 210, 47, 105, 4, 47, 216, 208, 32, 229, 111, 47, 0, 28, 242, 1 }, new byte[] { 233, 96, 197, 33, 182, 30, 71, 142, 224, 95, 197, 9, 206, 35, 147, 31, 219, 101, 144, 151, 167, 28, 92, 163, 1, 132, 228, 198, 160, 70, 242, 151, 198, 80, 143, 122, 66, 6, 0, 62, 171, 144, 126, 70, 234, 92, 140, 198, 192, 115, 218, 22, 128, 229, 166, 180, 124, 118, 103, 254, 62, 1, 61, 172, 33, 109, 1, 254, 91, 249, 186, 50, 252, 188, 231, 228, 206, 24, 97, 234, 167, 137, 123, 127, 188, 80, 89, 22, 184, 90, 203, 9, 87, 79, 141, 71, 75, 74, 98, 243, 119, 221, 7, 157, 11, 197, 108, 150, 171, 246, 117, 170, 75, 29, 5, 220, 134, 93, 87, 217, 98, 110, 245, 231, 151, 201, 157, 224 }, 1, new DateTime(2025, 5, 16, 12, 33, 36, 776, DateTimeKind.Local).AddTicks(7760), "system" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2025, 5, 16, 12, 33, 36, 776, DateTimeKind.Local).AddTicks(7770), "", new byte[] { 243, 222, 175, 88, 211, 12, 246, 224, 142, 141, 95, 234, 85, 203, 2, 99, 120, 183, 249, 246, 252, 129, 110, 48, 17, 12, 134, 33, 159, 148, 204, 194, 162, 74, 9, 33, 155, 210, 135, 130, 148, 88, 4, 5, 108, 250, 22, 81, 84, 210, 47, 105, 4, 47, 216, 208, 32, 229, 111, 47, 0, 28, 242, 1 }, new byte[] { 233, 96, 197, 33, 182, 30, 71, 142, 224, 95, 197, 9, 206, 35, 147, 31, 219, 101, 144, 151, 167, 28, 92, 163, 1, 132, 228, 198, 160, 70, 242, 151, 198, 80, 143, 122, 66, 6, 0, 62, 171, 144, 126, 70, 234, 92, 140, 198, 192, 115, 218, 22, 128, 229, 166, 180, 124, 118, 103, 254, 62, 1, 61, 172, 33, 109, 1, 254, 91, 249, 186, 50, 252, 188, 231, 228, 206, 24, 97, 234, 167, 137, 123, 127, 188, 80, 89, 22, 184, 90, 203, 9, 87, 79, 141, 71, 75, 74, 98, 243, 119, 221, 7, 157, 11, 197, 108, 150, 171, 246, 117, 170, 75, 29, 5, 220, 134, 93, 87, 217, 98, 110, 245, 231, 151, 201, 157, 224 }, 2, new DateTime(2025, 5, 16, 12, 33, 36, 776, DateTimeKind.Local).AddTicks(7770), "guest" }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("42b8d7a9-d8b8-4e9a-989b-90b82a821b0b"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5670), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5670) },
                    { new Guid("8137ca6f-c9fb-4587-991a-30e447c5c12f"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5680), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5680) },
                    { new Guid("cbad28ec-55db-4c0d-910d-2c7940e551ab"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5280), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(5290) }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Address", "AuthId", "CreatedAt", "DateOfBirth", "ImageUrl", "MonthlySalary", "Name", "PhoneNumber", "UpdatedAt" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), "Ho Chi Minh City", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(4220), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0m, "Admin", "0000000000", new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(4220) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "AuthId", "CreatedAt", "CustomerLevel", "DateOfBirth", "ImageUrl", "IsAvailable", "Name", "PhoneNumber", "Point", "UpdatedAt" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "Ho Chi Minh City", new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(3220), 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Guest", "0000000000", 0, new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "AuthId", "CreatedAt", "DateOfBirth", "DateStartWork", "ImageUrl", "MonthlySalary", "Name", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Ho Chi Minh City", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(1800), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0m, "Online System", "0000000000", 0, new DateTime(2025, 5, 16, 12, 33, 36, 777, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AuthId",
                table: "Admins",
                column: "AuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AuthId",
                table: "Customers",
                column: "AuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AuthId",
                table: "Employees",
                column: "AuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientExportOrders_IngredientStockId",
                table: "IngredientExportOrders",
                column: "IngredientStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientStocks_IngredientId",
                table: "IngredientStocks",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemHistories_MenuItemCategoryId",
                table: "MenuItemHistories",
                column: "MenuItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemHistories_MenuItemId",
                table: "MenuItemHistories",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuItemCategoryId",
                table: "MenuItems",
                column: "MenuItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuItemId",
                table: "OrderDetails",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromotionId",
                table: "Orders",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IngredientId",
                table: "Recipes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MenuItemId",
                table: "Recipes",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ShiftId",
                table: "Schedules",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_TableBookings_TableId",
                table: "TableBookings",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "IngredientExportOrders");

            migrationBuilder.DropTable(
                name: "MenuItemHistories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "TableBookings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IngredientStocks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "MenuItemCategories");

            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "Auths");
        }
    }
}
