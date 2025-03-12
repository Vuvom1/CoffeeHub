using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.PromtionDtos;
using CoffeeHub.Services.Interfaces;
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

        [HttpGet("usable/{customerId}")]
        public async Task<IActionResult> GetUsablePromotionsByCustomerId(Guid customerId)
        {
            var promotions = await _promotionService.GetUsablePromotionsByCustomerIdAsync(customerId);
            return Ok(promotions);
        }

        [HttpPut("{id}/activation")]
        public async Task<IActionResult> UpdatePromotionActivation(Guid id, [FromQuery] bool isActive)
        {
            await _promotionService.UpdatePromotionActivation(id, isActive);
            return Ok("Promotion activation updated successfully");
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _promotionService.GetAllAsync();
            var promotionDtos = _mapper.Map<IEnumerable<PromotionDto>>(promotions);
            return Ok(promotionDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromotionAddDto promotionDto)
        {
            var promotion = _mapper.Map<Promotion>(promotionDto);
            await _promotionService.AddAsync(promotion);
            return Ok("Promotion created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PromotionEditDto promotionDto)
        {
            var promotion = _mapper.Map<Promotion>(promotionDto);
            promotion.Id = id;
            await _promotionService.UpdateAsync(promotion);
            return Ok("Promotion updated successfully");
        }
    }
}
