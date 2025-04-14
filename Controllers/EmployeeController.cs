using AutoMapper;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.EmployeeDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "Admin, Customer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return Ok(employeeDtos);
        }

        [HttpGet("schedule")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllWithSchedule()
        {
            var employees = await _employeeService.GetAllWithScheduleAsync();
            // var employeeDtos = _mapper.Map<IEnumerable<EmployeeScheduleDto>>(employees);

            return Ok(employees);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> CreateWithAuth([FromBody] EmployeeAddDto employeeAddDto)
        {
            var employee = _mapper.Map<Employee>(employeeAddDto);

            await _employeeService.AddWithAuthAsync(employee, employeeAddDto.AuthId);

            return Ok("Employee created successfully");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {

            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeUpdateDto, employee);

            await _employeeService.UpdateAsync(employee);

            return Ok("Employee updated successfully");
        }

        [HttpPut("{id}/updateBasicInfo")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> UpdateBasicInfo(Guid id, [FromBody] EmployeeBasicInforUpdateDto employeeBasicInfoUpdateDto)
        {
            var employee = _mapper.Map<Employee>(employeeBasicInfoUpdateDto);

            _mapper.Map(employeeBasicInfoUpdateDto, employee);

            await _employeeService.UpdateBasicInforAsync(id, employee);

            return Ok("Employee basic info updated successfully");
        }

        [HttpPut("{id}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(Guid id, [FromBody] EmployeeRole employeeRole)
        {
            await _employeeService.UpdateRoleAsync(id, employeeRole);

            return Ok("Employee role updated successfully");
        }
    }
}
