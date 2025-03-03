using System;
using CoffeeHub.Models;

namespace CoffeeHub.Services.Interfaces;

public interface IAuthService : IBaseService<Auth>
{
    Task<Auth> Register(Auth auth, string password);
    Task<Auth> Login(string username, string password);
    Task<bool> UserExists(string username);
    string GenerateJwtToken(Auth user);
}
