using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IAuthService : IBaseService<Auth>
{
    Task<Auth> Register(Auth auth, string password);
    Task<Auth> RegisterWithRandomPassword(Auth auth);
    Task<Auth> RegisterEmployeeWithRandomPassword(Auth auth);   
    Task<Auth> Login(string username, string password);
    Task<bool> UserExists(string username);
    string GenerateJwtToken(Auth user);
}
