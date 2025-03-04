using CoffeeHub.Models.Domains;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientStockController : ControllerBase
    {
        private readonly IIngredientStockService _ingredientStockService;
        public IngredientStockController(IIngredientStockService ingredientStockService)
        {
            _ingredientStockService = ingredientStockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredientStocks = await _ingredientStockService.GetAllAsync();
            return Ok(ingredientStocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredientStock = await _ingredientStockService.GetByIdAsync(id);
            if (ingredientStock == null)
            {
                return NotFound("Ingredient stock not found");
            }
            return Ok(ingredientStock);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IngredientStock ingredientStock)
        {
            await _ingredientStockService.AddAsync(ingredientStock);
            return StatusCode(StatusCodes.Status201Created, "Ingredient stock created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IngredientStock ingredientStock)
        {
            var existingIngredientStock = await _ingredientStockService.GetByIdAsync(id);
            if (existingIngredientStock == null)
            {
                return NotFound();
            }
            await _ingredientStockService.UpdateAsync(ingredientStock);
            return Ok("Ingredient stock updated successfully");
        }
    }
}
