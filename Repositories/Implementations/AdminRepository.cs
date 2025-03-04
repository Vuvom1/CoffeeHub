using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class AdminRepository(CoffeeHubContext context) : BaseRepository<Admin>(context), IAdminRepository
{
    private new readonly CoffeeHubContext _context = context;
}
