using AutoMapper;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.OrderDetailDtos;
using CoffeeHub.Models.DTOs.OrderDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IDeliveryService deliveryService, IMapper mapper)
        {
            _orderService = orderService;
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(orderDtos);
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Create(OrderAddDto orderAddDto)
        {
            var order = _mapper.Map<Order>(orderAddDto);

            await _orderService.AddAsync(order);
            return StatusCode(StatusCodes.Status201Created, "Order created successfully.");
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, OrderStatus orderStatus)
        {
            await _orderService.UpadateOrderStatusAsync(id, orderStatus);
            return Ok("Order status updated successfully.");
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            await _orderService.CancelOrderAsync(id);
            return Ok();
        }

        [HttpPut("{id}/start-processing")]
        public async Task<IActionResult> StartProcessingOrder(Guid id)
        {
            await _orderService.StartProcessingOrderAsync(id);
            return Ok();
        }

        [HttpPut("{id}/start-preparing")]
        public async Task<IActionResult> StartPreparingOrder(Guid id)
        {
            await _orderService.StartPreparingOrderAsync(id);
            return Ok();
        }

        [HttpPut("{id}/mark-ready")]
        public async Task<IActionResult> MarkOrderAsReady(Guid id)
        {
            await _orderService.MarkOrderAsReadyAsync(id);
            return Ok();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteOrder(Guid id)
        {
            await _orderService.CompleteOrderAsync(id);
            return Ok();
        }
    }
}
