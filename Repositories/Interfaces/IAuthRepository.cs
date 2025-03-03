using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories;

public interface IAuthRepository : IBaseRepository<Auth>
{
    Task<Auth> Register(Auth auth, string password);
    Task<Auth> Login(string username, string password);
    Task<bool> UserExists(string username);
}
