using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.IngredientStockDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientStockController : ControllerBase
    {
        private readonly IIngredientStockService _ingredientStockService;
        private readonly IMapper _mapper;
        public IngredientStockController(IIngredientStockService ingredientStockService, IMapper mapper)
        {
            _ingredientStockService = ingredientStockService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var ingredientStocks = await _ingredientStockService.GetAllAsync();
            var ingredientStocksDto = _mapper.Map<IEnumerable<IngredientStockDto>>(ingredientStocks);
            return Ok(ingredientStocksDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ingredientStock = await _ingredientStockService.GetByIdAsync(id);
            if (ingredientStock == null)
            {
                return NotFound("Ingredient stock not found");
            }
            return Ok(ingredientStock);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(IngredientStockAddDto ingredientStockAddDto)
        {
            var ingredient = _mapper.Map<IngredientStock>(ingredientStockAddDto);
            await _ingredientStockService.AddAsync(ingredient);
            
            return StatusCode(StatusCodes.Status201Created, "Ingredient stock created successfully");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, IngredientStock ingredientStock)
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
