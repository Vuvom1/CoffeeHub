using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.DTOs.AdminDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var admin = await _adminService.GetByIdAsync(id);

            var adminDto = _mapper.Map<AdminDto>(admin);

            return Ok(adminDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _adminService.GetAllAsync();
            return Ok(admins);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AdminEditDto adminDto)
        {

            var admin = _mapper.Map<Admin>(adminDto);
            admin.Id = id;
            admin.AuthId = (await _adminService.GetByIdAsync(id)).AuthId;

            await _adminService.UpdateAsync(admin);

            return Ok();
        }
    }
}
