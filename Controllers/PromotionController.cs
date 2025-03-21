using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.PromtionDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly IMapper _mapper;

        public PromotionController(IPromotionService promotionService, IMapper mapper)
        {
            _promotionService = promotionService;
            _mapper = mapper;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActivePromotions()
        {
            var promotions = await _promotionService.GetActivePromotionsAsync();
            return Ok(promotions);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var promotion = await _promotionService.GetByCodeAsync(code);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpGet("usable/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsablePromotionsByCustomerId(Guid id)
        {
            var promotions = await _promotionService.GetUsablePromotionsByCustomerIdAsync(id);
            return Ok(promotions);
        }

        

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var promotion = await _promotionService.GetByIdAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _promotionService.GetAllAsync();
            var promotionDtos = _mapper.Map<IEnumerable<PromotionDto>>(promotions);
            return Ok(promotionDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PromotionAddDto promotionDto)
        {
            var promotion = _mapper.Map<Promotion>(promotionDto);
            await _promotionService.AddAsync(promotion);
            return Ok("Promotion created successfully");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, PromotionEditDto promotionDto)
        {
            var promotion = _mapper.Map<Promotion>(promotionDto);
            promotion.Id = id;
            await _promotionService.UpdateAsync(promotion);
            return Ok("Promotion updated successfully");
        }

        [HttpPut("activation/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePromotionActivation(Guid id, [FromBody] bool isActive)
        {
            await _promotionService.UpdateActivationAsync(id, isActive);
            return Ok("Promotion activation updated successfully");
        }
    }
}
