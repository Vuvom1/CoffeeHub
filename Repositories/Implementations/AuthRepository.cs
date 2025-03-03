using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CoffeeHub.Models;
using CoffeeHub.Enums;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class AuthRepository : BaseRepository<Auth>, IAuthRepository
{
    private new readonly CoffeeHubContext _context;
    public AuthRepository(CoffeeHubContext coffeeHubContext) : base(coffeeHubContext)
    {
        _context = coffeeHubContext;
    }

    public async Task<Auth> Login(string username, string password)
    {
        var user = await _context.Set<Auth>().FirstOrDefaultAsync(x => x.Username == username);
        if (user == null)
        {
            return null;
        }

        if (user.PasswordHash == null || user.PasswordSalt == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            return null;
        }

        return user;
    }

    public async Task<Auth> Register(Auth auth, string password)
    {
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        auth.PasswordHash = passwordHash;
        auth.PasswordSalt = passwordSalt;

        auth.IsAvailable = true;
        auth.Role = UserRole.Customer;

        await AddAsync(auth);
        return auth;
    }

    public Task<bool> UserExists(string username)
    {
        return _context.Set<Auth>().AnyAsync(x => x.Username == username);
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i])
            {
                return false;
            }
        }
        return true;
    }
}
