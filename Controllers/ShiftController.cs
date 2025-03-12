using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shifts = await _shiftService.GetAllAsync();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var shift = await _shiftService.GetByIdAsync(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shift shift)
        {
            await _shiftService.AddAsync(shift);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Shift shift)
        {
            var existingShift = await _shiftService.GetByIdAsync(id);
            if (existingShift == null)
            {
                return NotFound();
            }
            await _shiftService.UpdateAsync(shift);
            return Ok();
        }
    }
}
