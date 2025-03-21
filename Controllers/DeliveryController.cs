using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveryController : ControllerBase
    {

        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;

        public DeliveryController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deliveries = await _deliveryService.GetAllAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryAddDto delivery)
        {
            var deliveryDomain = _mapper.Map<Delivery>(delivery);
            await _deliveryService.AddAsync(deliveryDomain);
            return Ok("Delivery created successfully");
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(Guid id, DeliveryDto delivery)
        // {
        //     var existingDelivery = await _deliveryService.GetByIdAsync(id);
        //     if (existingDelivery == null)
        //     {
        //         return NotFound();
        //     }
        // }
    }
}
