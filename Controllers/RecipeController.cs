using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.RecipeDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {   
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpGet("menu-item/{menuItemId}")]
        public async Task<IActionResult> GetByMenuItemId(Guid menuItemId)
        {
            var recipes = await _recipeService.GetByMenuItemIdAsync(menuItemId);

            var recipeIngredientDtos = _mapper.Map<IEnumerable<RecipeIngredientDto>>(recipes);
            return Ok(recipeIngredientDtos);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllAsync();
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeAddDto recipeAddDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeAddDto);
            await _recipeService.AddAsync(recipe);
            
            return StatusCode(StatusCodes.Status201Created, "Recipe created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Recipe recipe)
        {
            var existingRecipe = await _recipeService.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                return NotFound();
            }
            await _recipeService.UpdateAsync(recipe);
            return Ok("Recipe updated successfully");
        }

        [HttpPut("menu-item/{menuItemId}")]
        public async Task<IActionResult> UpdateByMenuItemId(Guid menuItemId, RecipeIngredientEditDto[] recipeIngredientEditDtos)
        {
            var recipes = _mapper.Map<Recipe[]>(recipeIngredientEditDtos);
            await _recipeService.UpdateByMenuItemAsync(menuItemId, recipes);
            return Ok("Recipe updated successfully");
        }
    }
}
