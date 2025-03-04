using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
}
