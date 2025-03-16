using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IMenuItemCategoryService : IBaseService<MenuItemCategory>
{
    Task<IEnumerable<MenuItemCategory>> GetAllWithMenuItemsAsync();
}
