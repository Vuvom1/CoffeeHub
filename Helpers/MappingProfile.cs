using System;
using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.DTOs.AuthDtos;
using CoffeeHub.Models.DTOs.CustomerDtos;
using CoffeeHub.Models.DTOs.MenuItem;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CoffeeHub.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, Auth>();
        CreateMap<LoginDto, Auth>();   
        CreateMap<Customer, CustomerDto>();
        CreateMap<MenuItemDto, MenuItem>();
    }
}
