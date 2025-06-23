using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class IngredientExportOrderService : BaseService<IngredientExportOrder>, IIngredientExportOrderService
{
    private readonly IIngredientExportOrderRepository _ingredientExportOrderRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IIngredientStockRepository _ingredientStockRepository;
    public IngredientExportOrderService(
        IIngredientExportOrderRepository ingredientExportOrderRepository, 
        IIngredientRepository ingredientRepository,
        IIngredientStockRepository ingredientStockRepository) : base(ingredientExportOrderRepository)
    {
        _ingredientExportOrderRepository = ingredientExportOrderRepository;
        _ingredientRepository = ingredientRepository;
        _ingredientStockRepository = ingredientStockRepository;
    }

    public override async Task AddAsync(IngredientExportOrder entity)
    {
        //Update ingredient stock
        var ingredientStock = await _ingredientStockRepository.GetByIdAsync(entity.IngredientStockId);

        if (ingredientStock != null)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(ingredientStock.IngredientId);

            if (ingredient != null)
            {
                ingredientStock.Quantity -= entity.Quantity;
                ingredient.TotalQuantity -= entity.Quantity;

                await _ingredientStockRepository.UpdateAndReturnAsync(ingredientStock);
                await _ingredientRepository.UpdateAsync(ingredient);
            }
        }

        await base.AddAsync(entity);
    }
}
