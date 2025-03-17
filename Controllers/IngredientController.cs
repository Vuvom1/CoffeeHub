using System.Threading.Tasks;
using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.IngredientDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;
        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _ingredientService.GetAllAsync();
            var ingredientDtos = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);

            return Ok(ingredientDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpGet("ids")]
        public async Task<IActionResult> GetByIds([FromQuery] IEnumerable<Guid> ids)
        {
            var ingredients = await _ingredientService.GetByIdsAsync(ids);
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IngredientAddDto ingredientAddDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientAddDto);
            await _ingredientService.AddAsync(ingredient);
            return Ok("New ingredient created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, IngredientEditDto ingredientEditDto)
        {
            var ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            _mapper.Map(ingredientEditDto, ingredient);
            await _ingredientService.UpdateAsync(ingredient);
            return Ok("Ingredient updated");
        }
    }
}
