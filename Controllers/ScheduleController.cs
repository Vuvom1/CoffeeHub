using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.ScheduleDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;
        public ScheduleController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAllAsync();
            var scheduleDtos = _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
            
            return Ok(scheduleDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            var scheduleDto = _mapper.Map<ScheduleDto>(schedule);

            return Ok(scheduleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleAddDto scheduleAddDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleAddDto);
            await _scheduleService.AddAsync(schedule);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ScheduleEditDto scheduleEditDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleEditDto);

            await _scheduleService.UpdateAsync(schedule);

            return Ok();
        }
    }
}
