using System;
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

    public override async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await _context.Employees.Include(x => x.Auth).FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException($"Employee with ID {id} not found.");
        Console.WriteLine(employee);
        return employee;
    }
}
