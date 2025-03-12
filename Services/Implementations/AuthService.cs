using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoffeeHub.Repositories;
using CoffeeHub.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Implementations;

public class AuthService : BaseService<Auth>, IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AuthService(IAuthRepository authRepository, IConfiguration configuration, IEmailService emailService) : base(authRepository)
    {
        _authRepository = authRepository;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<Auth> Register(Auth auth, string password)
    {
        if (auth.Username == null || await _authRepository.UserExists(auth.Username))
        {
            throw new Exception("Username already exists");
        }

        if (auth.Email == null || await _authRepository.EmailExists(auth.Email))
        {
            throw new Exception("Email already exists");
        }

        auth.Role = UserRole.Customer;

        return await _authRepository.Register(auth, password);
    }

    public async Task<Auth> RegisterWithRandomPassword(Auth auth)
    {
        var randomPassword = GenerateRandomPassword();

        return await _authRepository.Register(auth, randomPassword);
    }

    public async Task<Auth> RegisterEmployeeWithRandomPassword(Auth auth)
    {
        var randomPassword = GenerateRandomPassword();
        auth.Role = UserRole.Employee;

        Console.WriteLine(auth);

        var message = $"Dear {auth.Username},\n\n" +
                      $"Your account has been created successfully. Here are your login details:\n\n" +
                      $"Username: {auth.Username}\n" +
                      $"Password: {randomPassword}\n\n" +
                      $"Please change your password after logging in for the first time.\n\n" +
                      $"Best regards,\n" +
                      $"CoffeeHub Team";

        await _emailService.SendEmailAsync(auth.Email, "CoffeeHub Account Created", message);

        return await _authRepository.Register(auth, randomPassword);
    }
    public async Task<Auth> Login(string username, string password)
    {
    
        return await _authRepository.Login(username, password);
    }

    public async Task<bool> UserExists(string username)
    {
        return await _authRepository.UserExists(username);
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _authRepository.EmailExists(email);
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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

    private string GenerateRandomPassword()
    {
        int length = 12;
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (length > 0)
        {
            res.Append(validChars[rnd.Next(validChars.Length)]);
            length--;
        }
        return res.ToString();
    }

    
}