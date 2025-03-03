using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class AdminService : BaseService<Admin>, IAdminService
{
    private readonly IAdminRepository _adminRepository;
    public AdminService(IAdminRepository adminRepository) : base(adminRepository)
    {
        _adminRepository = adminRepository;
    }
}
