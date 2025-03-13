using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    public Task<IEnumerable<Customer>> GetAllWithAuthAsync();
    public Task<Customer?> GetByEmailAsync(string email);
    public Task<Customer?> GetByPhoneNumberAsync(string phone);
    public Task<Customer?> GetWithAuthByIdAsync(Guid id);
    public Task<bool> IsActiveAsync(Guid id);
    public Task IncreasePointAsync(Guid id, int point);
    public Task DecreasePointAsync(Guid id, int point);
    public Task UpdateActivationAsync(Guid id, bool isActive);
}
