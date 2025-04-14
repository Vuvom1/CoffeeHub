using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class AdminService : BaseService<Admin>, IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAuthService _authService;
    public AdminService(IAdminRepository adminRepository, IAuthService authService) : base(adminRepository)
    {
        _adminRepository = adminRepository;
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public override async Task<Admin> GetByIdAsync(Guid id)
    {
        return await _adminRepository.GetWithAuthAsync(id);
    }

}
