using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.DTOs.MenuItem;
using CoffeeHub.Services.Interfaces;
using FirebaseAdmin;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using CoffeeHub.Models.DTOs.MenuItemDtos;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.RecipeDtos;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMapper _mapper;

        public MenuItemController(IMenuItemService menuItemService, IMapper mapper)
        {
            _menuItemService = menuItemService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _menuItemService.GetAllAsync();
            var menuItemDtos = _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
            
            return Ok(menuItemDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItemAddDto menuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            await _menuItemService.AddAsync(menuItem);
            return Ok("MenuItem created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, MenuItemEditDto menuItemEditDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemEditDto);
            menuItem.Id = id;
            await _menuItemService.UpdateAsync(menuItem);
            return Ok("MenuItem updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            await _menuItemService.DeleteAsync(menuItem);
            return Ok("MenuItem deleted successfully");
        }

        [HttpPut("updateAvailability")]
        public async Task<IActionResult> UpdateAvailability(Guid id)
        {
            var menuItem = await _menuItemService.UpdateMenuItemAvailabilityAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok("MenuItem availability updated successfully");
        }
    }
}
