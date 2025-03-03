using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    private new readonly CoffeeHubContext _context;
    public AdminRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    
}
