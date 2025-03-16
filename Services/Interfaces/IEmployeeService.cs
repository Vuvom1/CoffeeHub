using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IEmployeeService : IBaseService<Employee>
{
    public Task<IEnumerable<Employee>> GetAllWithScheduleAsync();
    public Task<Employee> AddAndReturnAsync(Employee employee);
    public  Task<Employee> AddWithAuthAsync(Employee employee, Guid authId);
}
