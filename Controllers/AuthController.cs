using Microsoft.AspNetCore.Mvc;
using CoffeeHub.Models;
using CoffeeHub.Services.Interfaces;
using AutoMapper;
using CoffeeHub.Models.DTOs.AuthDtos;

namespace CoffeeHub.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var auth = _mapper.Map<Auth>(registerDto);
            var registeredAuth = await _authService.Register(auth, registerDto.Password);
            return Ok(registeredAuth);
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

        var token = _authService.GenerateJwtToken(user);
        return Ok(new { token });
    }

    [HttpGet("user-exists")]
    public async Task<IActionResult> UserExists([FromQuery] string username)
    {
        var userExists = await _authService.UserExists(username);
        return Ok(userExists);
    }
}