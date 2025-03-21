using System;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private new readonly CoffeeHubContext _context;
    public EmployeeRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public Task<Employee> AddAndReturnAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return Task.FromResult(employee);
    }

    public async Task<IEnumerable<Employee>> GetAllWithScheduleAsync()
    {
        return await _context.Employees
            .Include(x => x.Schedules)
                .ThenInclude(x => x.Shift)
            .ToListAsync();
    }

    public override async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await _context.Employees.Include(x => x.Auth).FirstOrDefaultAsync(x => x.Id == id);

        if (employee == null)
        {
            return null;
        }
        
        return employee;
    }

    public async Task UpdateRoleAsync(Guid id, EmployeeRole role)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (employee != null)
        {
            employee.Role = role;
            await _context.SaveChangesAsync();
        }
    }
}
