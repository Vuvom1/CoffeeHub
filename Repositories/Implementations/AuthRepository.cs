using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CoffeeHub.Models;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Implementations;

public class AuthRepository(CoffeeHubContext coffeeHubContext) : BaseRepository<Auth>(coffeeHubContext), IAuthRepository
{
    private new readonly CoffeeHubContext _context = coffeeHubContext;

    public override async Task<Auth> GetByIdAsync(Guid id)
    {
        var auth = await _context.Auths.Include(x => x.Customer)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new InvalidOperationException("User not found.");
        

        return auth;
    }

    public async Task<Auth> Login(string username, string password)
    {
        var user = await _context.Set<Auth>()
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .Include(x => x.Admin)
            .FirstOrDefaultAsync(x => x.Username == username);
            
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        if (user.PasswordHash == null || user.PasswordSalt == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new InvalidOperationException("Invalid password.");
        }

        return user;
    }

    public async Task<Auth> Register(Auth auth, string password)
    {
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        auth.PasswordHash = passwordHash;
        auth.PasswordSalt = passwordSalt;

        auth.IsAvailable = true;

        await AddAsync(auth);
        return auth;
    }

    public Task<bool> UserExists(string username)
    {
        return _context.Set<Auth>().AnyAsync(x => x.Username == username);
    }

    public Task<bool> EmailExists(string email)
    {
        return _context.Set<Auth>().AnyAsync(x => x.Email == email);
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
