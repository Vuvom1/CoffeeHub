using AutoMapper;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.CustomerDtos;
using CoffeeHub.Models.DTOs.DeliveryDtos;
using CoffeeHub.Models.DTOs.OrderDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IDeliveryService deliveryService, IAuthService authService, IMapper mapper)
        {
            _customerService = customerService;
            _deliveryService = deliveryService;
            _authService = authService;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllWithAuthAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);    

            return Ok(customerDtos);
        }

        [HttpGet("phone/{phone}")]
        [Authorize(Roles= "Admin, Employee")]
        public async Task<IActionResult> GetByPhoneNumber(string phone)
        {
            var customer = await _customerService.GetByPhoneNumberAsync(phone);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        [Authorize]
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
