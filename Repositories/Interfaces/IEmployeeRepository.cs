using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee> AddAndReturnAsync(Employee employee);
}
