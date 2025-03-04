using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoffeeHub.Models;
using CoffeeHub.Repositories;
using CoffeeHub.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeHub.Services.Implementations;

public class AuthService : BaseService<Auth>, IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository authRepository, IConfiguration configuration) : base(authRepository)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<Auth> Register(Auth auth, string password)
    {
        if (auth.Username == null || await _authRepository.UserExists(auth.Username))
        {
            throw new Exception("Username already exists");
        }

        return await _authRepository.Register(auth, password);
    }

    public async Task<Auth> Login(string username, string password)
    {
    
        return await _authRepository.Login(username, password);
    }

    public async Task<bool> UserExists(string username)
    {
        return await _authRepository.UserExists(username);
    }

    public string GenerateJwtToken(Auth user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtKey = _configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new ArgumentNullException("Jwt:Key", "JWT key is not configured.");
        }
        var key = Encoding.ASCII.GetBytes(jwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username ?? throw new ArgumentNullException(nameof(user.Username))),
                new Claim(ClaimTypes.Email, user.Email ?? throw new ArgumentNullException(nameof(user.Email))),
                new Claim(ClaimTypes.Role, user.Role?.ToString() ?? throw new ArgumentNullException(nameof(user.Role)))
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}