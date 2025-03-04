using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private new readonly CoffeeHubContext _context;
    public EmployeeRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

}
