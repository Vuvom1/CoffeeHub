using System;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllWithScheduleAsync();
    Task UpdateRoleAsync(Guid id, EmployeeRole role);
    Task<Employee> AddAndReturnAsync(Employee employee);
}
