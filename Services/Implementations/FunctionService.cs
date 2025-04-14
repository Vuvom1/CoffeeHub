using System;
using CoffeeHub.Repositories.Interfaces;
using Newtonsoft.Json;

namespace CoffeeHub.Services.Implementations;

public class FunctionService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMenuItemRepository _menuItemRepository;

    public FunctionService(IServiceProvider serviceProvider, IMenuItemRepository menuItemRepository)
    {
        _serviceProvider = serviceProvider;
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<string> ExecuteFunctionAsync(string functionName, dynamic parameters)
    {
        switch (functionName)
        {
            case "GetPopularMenuItems":
                int topCount = parameters.topCount;
                var popularMenuItems = await _menuItemRepository.GetPopularMenuItemsAsync(topCount);
                 return JsonConvert.SerializeObject(popularMenuItems.ToList(), new JsonSerializerSettings
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                 });
            case "GetMenuItemDetails":
                string menuItemId = parameters.menuItemId;
                return await GetMenuItemDetails(menuItemId);
            case "GetNewestMenuItem":
                int newestTopCount = parameters.topCount;
                var newestMenuItems = await _menuItemRepository.GetNewestMenuItemsAsync(newestTopCount);
                return JsonConvert.SerializeObject(newestMenuItems.ToList());
            default:
                throw new Exception($"Function '{functionName}' not implemented.");
        }
    }

    private async Task<string> GetMenuItemDetails(string menuItemId)
    {
        // Simulate fetching menu item details
        return $"Details for Menu Item ID: {menuItemId}";
    }
}
