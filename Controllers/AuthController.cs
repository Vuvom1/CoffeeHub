using Microsoft.AspNetCore.Mvc;
using CoffeeHub.Services.Interfaces;
using AutoMapper;
using CoffeeHub.Models.DTOs.AuthDtos;
using CoffeeHub.Models.Domains;
using CoffeeHub.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeHub.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;

        _mapper = mapper;
    }

    [HttpGet("details")]
    public async Task<IActionResult> GetDetails([FromQuery] Guid id)
    {
        var auth = await _authService.GetByIdAsync(id);
        if (auth == null)
        {
            return NotFound();
        }

        var authDto = _mapper.Map<AuthDto>(auth);
        return Ok(authDto);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var auth = _mapper.Map<Auth>(registerDto);
            if (string.IsNullOrEmpty(registerDto.Password))
            {
                return BadRequest(new { message = "Password cannot be null or empty" });
            }

            var registeredAuth = await _authService.Register(auth, registerDto.Password);
            return Ok("User registered successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("register-customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registerDto)
    {
        var auth = _mapper.Map<Auth>(registerDto);
        var customer = _mapper.Map<Customer>(registerDto.Customer);

        await _authService.RegisterCustomer(auth, customer, registerDto.Password);
        return Ok("Customer registered successfully");
    }

    [HttpPost("register-employee")]
    public async Task<IActionResult> RegisterEmployee([FromBody] RegisterDto registerDto)
    {
        try
        {
            var auth = _mapper.Map<Auth>(registerDto);
            var registeredAuth = await _authService.RegisterEmployeeWithRandomPassword(auth);
            return Ok("Employee registered successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _authService.Login(loginDto.Username, loginDto.Password);
        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        var userRole = user.Role.ToString();
        var isVerified = user.Admin != null || user.Employee != null || user.Customer != null;

        var token = _authService.GenerateJwtToken(user);
        return Ok(new { token, userRole, isVerified });
    }

    [HttpGet("user-exists")]
    public async Task<IActionResult> UserExists([FromQuery] string username)
    {
        var userExists = await _authService.UserExists(username);
        return Ok(userExists);
    }
}