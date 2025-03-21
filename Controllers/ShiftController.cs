using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.ShiftDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly IMapper _mapper;
        public ShiftController(IShiftService shiftService, IMapper mapper)
        {
            _shiftService = shiftService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> GetAll()
        {
            var shifts = await _shiftService.GetAllAsync();
            var shiftDtos = _mapper.Map<IEnumerable<ShiftDto>>(shifts);

            return Ok(shiftDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var shift = await _shiftService.GetByIdAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            var shiftDto = _mapper.Map<ShiftDto>(shift);
            return Ok(shiftDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ShiftAddDto shiftAddDto)
        {
            var shift = _mapper.Map<Shift>(shiftAddDto);
            await _shiftService.AddAsync(shift);
            
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        [Authorize]
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
