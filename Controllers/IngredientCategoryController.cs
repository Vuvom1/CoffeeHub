using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.IngredientCategoryDtos;
using CoffeeHub.Models.DTOs.IngredientDtos;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientCategoryController : ControllerBase
    {
        private readonly IIngredientCategoryService _ingredientCategoryService;
        private readonly IMapper _mapper;

        public IngredientCategoryController(IIngredientCategoryService ingredientCategoryService, IMapper mapper)
        {
            _ingredientCategoryService = ingredientCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientCategoryDto>>> GetIngredientCategories()
        {
            var ingredientCategories = await _ingredientCategoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<IngredientCategoryDto>>(ingredientCategories));
        }

        [HttpGet("{id}", Name = "GetIngredientCategoryById")]
        public async Task<ActionResult<IngredientCategoryDto>> GetIngredientCategoryById(Guid id)
        {
            var ingredientCategory = await _ingredientCategoryService.GetByIdAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IngredientCategoryDto>(ingredientCategory));
        }

        [HttpPost]
        public async Task<ActionResult> CreateIngredientCategory(IngredientCategoryAddDto ingredientCategoryAddDto)
        {
            var ingredientCategory = _mapper.Map<IngredientCategory>(ingredientCategoryAddDto);
            await _ingredientCategoryService.AddAsync(ingredientCategory);
            return Ok("New ingredient category created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIngredientCategory(Guid id, IngredientCategoryEditDto ingredientCategoryEditDto)
        {
            var ingredientCategory = await _ingredientCategoryService.GetByIdAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }
            _mapper.Map(ingredientCategoryEditDto, ingredientCategory);
            await _ingredientCategoryService.UpdateAsync(ingredientCategory);
            return Ok("Ingredient category updated");
        }
    }
}
