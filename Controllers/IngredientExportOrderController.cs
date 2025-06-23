using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.IngredientExportOrderDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientExportOrderController : ControllerBase
    {
        private readonly IIngredientExportOrderService _ingredientExportOrderService;
        private readonly IMapper _mapper;

        public IngredientExportOrderController(IIngredientExportOrderService ingredientExportOrderService, IMapper mapper)
        {
            _ingredientExportOrderService = ingredientExportOrderService;
            _mapper = mapper;
        }

        // GET: api/IngredientExportOrder
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ingredientExportOrderService.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/IngredientExportOrder/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _ingredientExportOrderService.GetByIdAsync(id);
            if (order == null) return NotFound();
            var orderDto = _mapper.Map<IngredientExportOrderDto>(order);    
            return Ok(orderDto);
        }

        // POST: api/IngredientExportOrder
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddIngredientExportOrderDto orderDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = _mapper.Map<IngredientExportOrder>(orderDto);
            await _ingredientExportOrderService.AddAsync(order);

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        // PUT: api/IngredientExportOrder/{id}
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(Guid id, [FromBody] IngredientExportOrderUpdateDto orderDto)
        // {
        //     if (id != orderDto.Id) return BadRequest("ID mismatch.");

        //     if (!ModelState.IsValid) return BadRequest(ModelState);

        //     var order = await _ingredientExportOrderService.GetByIdAsync(id);
        //     if (order == null) return NotFound();

        //     _mapper.Map(orderDto, order);
        //     await _ingredientExportOrderService.UpdateAsync(order);

        //     return NoContent();
        // }

        // DELETE: api/IngredientExportOrder/{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _ingredientExportOrderService.GetByIdAsync(id);
            if (order == null) return NotFound();

            await _ingredientExportOrderService.DeleteAsync(order);

            return NoContent();
        }
    }
}
