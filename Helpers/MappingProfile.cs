using System;
using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.AdminDtos;
using CoffeeHub.Models.DTOs.AuthDtos;
using CoffeeHub.Models.DTOs.CustomerDtos;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.EmployeeDtos;
using CoffeeHub.Models.DTOs.IngredientCategoryDtos;
using CoffeeHub.Models.DTOs.IngredientDtos;
using CoffeeHub.Models.DTOs.IngredientExportOrderDtos;
using CoffeeHub.Models.DTOs.IngredientStockDtos;
using CoffeeHub.Models.DTOs.MenuItem;
using CoffeeHub.Models.DTOs.MenuItemCategoryDtos;
using CoffeeHub.Models.DTOs.MenuItemDtos;
using CoffeeHub.Models.DTOs.OrderDetailDtos;
using CoffeeHub.Models.DTOs.OrderDtos;
using CoffeeHub.Models.DTOs.PromtionDtos;
using CoffeeHub.Models.DTOs.RecipeDtos;
using CoffeeHub.Models.DTOs.ScheduleDtos;
using CoffeeHub.Models.DTOs.ShiftDtos;
using CoffeeHub.Models.DTOs.TableBookingDtos;
using CoffeeHub.Models.DTOs.TableDtos;

namespace CoffeeHub.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, Auth>();
        CreateMap<LoginDto, Auth>();   
        CreateMap<Auth, AuthDto>();
        CreateMap<AuthDto, Auth>();
        CreateMap<AuthAddDto, Auth>();
        CreateMap<Auth, AuthAddDto>();
        CreateMap<RegisterCustomerDto, Auth>();

        CreateMap<Admin, AdminDto>();
        CreateMap<AdminEditDto, Admin>();

        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();
        CreateMap<EmployeeAddDto, Employee>();
        CreateMap<EmployeeUpdateDto, Employee>();
        CreateMap<EmployeeBasicInforUpdateDto, Employee>();

        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerAddDto, Customer>();
        
        CreateMap<MenuItemDto, MenuItem>();
        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<MenuItemAddDto, MenuItem>();
        CreateMap<MenuItemEditDto, MenuItem>();
        
        CreateMap<MenuItemCategoryDto, MenuItemCategory>();
        CreateMap<MenuItemCategoryAddDto, MenuItemCategory>();

        CreateMap<RecipeUpdateByMenuItemDto, Recipe>();
        CreateMap<Recipe, RecipeIngredientDto>();
        CreateMap<RecipeIngredientEditDto, Recipe>();
        CreateMap<RecipeIngredientDto, Recipe>();

        CreateMap<IngredientDto, Ingredient>();
        CreateMap<Ingredient, IngredientDto>();
        CreateMap<IngredientAddDto, Ingredient>();
        CreateMap<IngredientEditDto, Ingredient>();

        CreateMap<IngredientCategory, IngredientCategoryDto>();
        CreateMap<IngredientCategoryAddDto, IngredientCategory>();
        CreateMap<IngredientCategoryEditDto, IngredientCategory>();

        CreateMap<IngredientStock, IngredientStockDto>();
        CreateMap<IngredientStockDto, IngredientStock>();
        CreateMap<IngredientStockAddDto, IngredientStock>();

        CreateMap<OrderDto, Order>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderAddDto, Order>();   
        CreateMap<OrderDetail, OrderDetailDto>();

        CreateMap<OrderDetailAddDto, OrderDetail>(); 

        CreateMap<Promotion, PromotionDto>();
        CreateMap<PromotionDto, Promotion>();
        CreateMap<PromotionAddDto, Promotion>();
        CreateMap<PromotionEditDto, Promotion>();

        CreateMap<Delivery, DeliveryDto>();
        CreateMap<DeliveryDto, Delivery>();
        CreateMap<DeliveryAddDto, Delivery>();

        CreateMap<ShiftAddDto, Shift>();
        CreateMap<Shift, ShiftDto>();
        CreateMap<ShiftDto, Shift>();

        CreateMap<Schedule, ScheduleDto>();
        CreateMap<ScheduleDto, Schedule>();
        CreateMap<ScheduleAddDto, Schedule>();
        CreateMap<ScheduleEditDto, Schedule>();

        CreateMap<Table, TableDto>();
        CreateMap<TableDto, Table>();
        CreateMap<AddTableDto, Table>();
        CreateMap<UpdateTableDto, Table>();

        CreateMap<TableBooking, TableBookingDto>();
        CreateMap<TableBookingDto, TableBooking>();
        CreateMap<AddTableBookingDto, TableBooking>();
        CreateMap<UpdateTableBookingDto, TableBooking>();

        CreateMap<IngredientExportOrder, IngredientExportOrderDto>();
        CreateMap<IngredientExportOrderDto, IngredientExportOrder>();
        CreateMap<AddIngredientExportOrderDto, IngredientExportOrder>();
        
    }
}
