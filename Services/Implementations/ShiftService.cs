using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class ShiftService : BaseService<Shift>, IShiftService
{
    private readonly IShiftRepository _shiftRepository;
    public ShiftService(IShiftRepository shiftRepository ) : base(shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }
}
