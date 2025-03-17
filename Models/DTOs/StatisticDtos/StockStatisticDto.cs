using System;
using CoffeeHub.Models.DTOs.IngredientDtos;

namespace CoffeeHub.Models.DTOs.StatisticDtos;

public class StockStatisticDto
{
    public IEnumerable<IngredientDto> IngredientsWithLowStock { get; set; }
    public IEnumerable<IngredientDto> IngredientsWithHighStock { get; set; }
}
