using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.CustomerDtos;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.OrderDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IDeliveryService deliveryService, IMapper mapper)
        {
            _customerService = customerService;
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerService.GetWithAuthByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("getByAuthId/{id}")]
        public async Task<IActionResult> GetByAuthId(Guid id)
        {
            var customer = await _customerService.GetByAuthIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllWithAuthAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);    

            return Ok(customerDtos);
        }

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetByPhoneNumber(string phone)
        {
            var customer = await _customerService.GetByPhoneNumberAsync(phone);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithAuth([FromBody] CustomerAddDto customerAddDto
        )
        {
            var customer = _mapper.Map<Customer>(customerAddDto);

            await _customerService.AddWithAuthAsync(customer, customerAddDto.AuthId);

            return Ok("Employee created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            customer.Id = id;
            await _customerService.UpdateAsync(customer);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(customer);
            return Ok("Customer deleted successfully");
        }
    }
}
