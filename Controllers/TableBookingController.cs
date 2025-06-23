using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.TableBookingDtos;
using CoffeeHub.Models.DTOs.TableDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableBookingController : ControllerBase
    {
        private readonly ITableBookingService _tableBookingService;
        private readonly IMapper _mapper;

        public TableBookingController(
            ITableBookingService tableBookingService,
            IMapper mapper)
        {
            _tableBookingService = tableBookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTableBookings()
        {
            var bookings = await _tableBookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableBookingById(Guid id)
        {
            var booking = await _tableBookingService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDto = _mapper.Map<TableBookingDto>(booking);
            return Ok(bookingDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTableBooking([FromBody] AddTableBookingDto tableBookingDto)
        {
            if (tableBookingDto == null)
            {
                return BadRequest("Table booking cannot be null.");
            }

            var tableBooking = _mapper.Map<TableBooking>(tableBookingDto);

            await _tableBookingService.AddAsync(tableBooking);
            return Ok("Table booking created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTableBooking(Guid id, [FromBody] UpdateTableBookingDto tableBookingDto)
        {
            var existingTableBooking = await _tableBookingService.GetByIdAsync(id);

            var tableBooking = _mapper.Map<TableBooking>(tableBookingDto);

            await _tableBookingService.UpdateAsync(tableBooking);
            return Ok("Table booking updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableBooking(Guid id)
        {
            var existingTableBooking = await _tableBookingService.GetByIdAsync(id);

            await _tableBookingService.DeleteAsync(existingTableBooking);
            return Ok("Table booking deleted successfully.");
        }
    }
}
