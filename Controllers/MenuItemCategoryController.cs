using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.MenuItemCategoryDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemCategoryController : ControllerBase
    {

        private readonly IMenuItemCategoryService _menuItemCategoryService;
        private readonly IMapper _mapper;

        public MenuItemCategoryController(IMenuItemCategoryService menuItemCategoryService, IMapper mapper)
        {
            _menuItemCategoryService = menuItemCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItemCategories = await _menuItemCategoryService.GetAllAsync();
            return Ok(menuItemCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItemCategory = await _menuItemCategoryService.GetByIdAsync(id);
            if (menuItemCategory == null)
            {
                return NotFound();
            }
            return Ok(menuItemCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItemCategoryDto menuItemCategory)
        {
            var menuItemCategoryDomain = _mapper.Map<MenuItemCategory>(menuItemCategory);
            await _menuItemCategoryService.AddAsync(menuItemCategoryDomain);
            return StatusCode(StatusCodes.Status201Created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItemCategoryDto menuItemCategory)
        {
            var existingMenuItemCategory = await _menuItemCategoryService.GetByIdAsync(id);
            if (existingMenuItemCategory == null)
            {
                return NotFound();
            }
            var menuItemCategoryDomain = _mapper.Map<MenuItemCategory>(menuItemCategory);
            await _menuItemCategoryService.UpdateAsync(menuItemCategoryDomain);
            return Ok();
        }
    }
}
