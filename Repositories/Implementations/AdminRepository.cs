using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class AdminRepository(CoffeeHubContext context) : BaseRepository<Admin>(context), IAdminRepository
{
    private new readonly CoffeeHubContext _context = context;

    public Task<Admin> GetWithAuthAsync(Guid id)
    {
        return _context.Admins.Include(a => a.Auth).FirstOrDefaultAsync(a => a.Id == id)!;
    }
}
