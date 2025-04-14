using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoffeeHub.Repositories;
using CoffeeHub.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using CoffeeHub.Enums;
using Newtonsoft.Json;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Implementations;

public class AuthService : BaseService<Auth>, IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IEmployeeService _employeeService;
    private readonly ICustomerService _customerService;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AuthService(IAuthRepository authRepository, IEmployeeService employeeService, ICustomerService customerService, IConfiguration configuration, IEmailService emailService) : base(authRepository)
    {
        _authRepository = authRepository;
        _employeeService = employeeService;
        _customerService = customerService;
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

    public async Task<Auth> RegisterCustomer(Auth auth, Customer customer, string password)
    {
        auth.Role = UserRole.Customer;
    
        var createdAuth = Register(auth, password).Result;
        
        customer.AuthId = createdAuth.Id;

        await _customerService.AddAsync(customer);
        
        return createdAuth;
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
        var user = await _authRepository.Login(username, password);

        return user;
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
        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];
        
        if (string.IsNullOrEmpty(jwtIssuer))
        {
            throw new ArgumentNullException("Jwt:Issuer", "JWT issuer is not configured.");
        }
        if (string.IsNullOrEmpty(jwtAudience))
        {
            throw new ArgumentNullException("Jwt:Audience", "JWT audience is not configured.");
        }

        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new ArgumentNullException("Jwt:Key", "JWT key is not configured.");
        }
        var key = Encoding.ASCII.GetBytes(jwtKey);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("username", user.Username ?? throw new ArgumentNullException(nameof(user.Username))),
            new Claim(ClaimTypes.Email, user.Email ?? throw new ArgumentNullException(nameof(user.Email))),
            new Claim(ClaimTypes.Role, user.Role?.ToString() ?? throw new ArgumentNullException(nameof(user.Role))),
        };

        if (user.Role == UserRole.Employee && user.Employee != null)
        {
            claims.Add(new Claim("id", user.Employee.Id.ToString()));
            claims.Add(new Claim("name", user.Employee.Name));
            if (user.Employee.ImageUrl != null)
            {
                claims.Add(new Claim("imageUrl", user.Employee.ImageUrl.ToString()));
            }
            claims.Add(new Claim("position", user.Employee.Role.ToString()));
            claims.Add(new Claim("address", user.Employee.Address.ToString()));
            claims.Add(new Claim("phoneNumber", user.Employee.PhoneNumber.ToString()));
        } else if (user.Role == UserRole.Customer && user.Customer != null)
        {
            claims.Add(new Claim("id", user.Customer.Id.ToString()));
            claims.Add(new Claim("name", user.Customer.Name ?? throw new ArgumentNullException(nameof(user.Customer.Name))));
            if (user.Customer.ImageUrl != null)
            {
                claims.Add(new Claim("imageUrl", user.Customer.ImageUrl.ToString()));
            }
            claims.Add(new Claim("address", user.Customer.Address?.ToString() ?? throw new ArgumentNullException(nameof(user.Customer.Address))));
            claims.Add(new Claim("phoneNumber", user.Customer.PhoneNumber?.ToString() ?? throw new ArgumentNullException(nameof(user.Customer.PhoneNumber))));
        } else if (user.Role == UserRole.Admin)
        {
            claims.Add(new Claim("id", user.Admin.Id.ToString()));
            if (user.Admin.ImageUrl != null)
            {
                claims.Add(new Claim("imageUrl", user.Admin.ImageUrl.ToString()));
            }
            claims.Add(new Claim("name", user.Admin.Name ?? throw new ArgumentNullException(nameof(user.Admin.Name))));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = jwtAudience,
            Issuer = jwtIssuer,
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