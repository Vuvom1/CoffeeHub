using AutoMapper;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.OrderDetailDtos;
using CoffeeHub.Models.DTOs.OrderDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(orderDtos);
        }

        [HttpGet("viewable-by-user-id")]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> GetAllViewableByUserId([FromQuery]Guid id)
        {
            var orders = await _orderService.GetAllViewableByUserId(id);
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(orderDtos);
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> Create(OrderAddDto orderAddDto)
        {
            var order = _mapper.Map<Order>(orderAddDto);

            await _orderService.AddAsync(order);
            return StatusCode(StatusCodes.Status201Created, "Order created successfully.");
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles= "Admin, Employee")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, OrderStatus orderStatus)
        {
            await _orderService.UpadateOrderStatusAsync(id, orderStatus);
            return Ok("Order status updated successfully.");
        }
    }
}
