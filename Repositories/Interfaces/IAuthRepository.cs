using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories;

public interface IAuthRepository : IBaseRepository<Auth>
{
    Task<Auth> Register(Auth auth, string password);
    Task<Auth> Login(string username, string password);
    Task<bool> UserExists(string username);
    Task<bool> EmailExists(string email);
}
