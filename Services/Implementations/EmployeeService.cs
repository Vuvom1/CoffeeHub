using System;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories;

namespace CoffeeHub.Services.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAuthRepository _authRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IAuthRepository authRepository) : base(employeeRepository)
    {
        _employeeRepository = employeeRepository;
        _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
    }

    public Task<Employee> AddAndReturnAsync(Employee employee)
    {
        return _employeeRepository.AddAndReturnAsync(employee);
    }

    public async Task<Employee> AddWithAuthAsync(Employee employee, Guid authId)
    {
        Console.WriteLine(authId);
        var addedEmployee = await _employeeRepository.AddAndReturnAsync(employee);
        var auth = await _authRepository.GetByIdAsync(authId);
        
        if (auth == null)
        {
            throw new Exception("Auth not found");
        }

        auth.EmployeeId = addedEmployee.Id;
        await _authRepository.UpdateAsync(auth);

        return addedEmployee;
    }
}
