using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface ICustomerService : IBaseService<Customer>
{
    public Task<Customer> AddWithAuthAsync(Customer customer, Guid authId);
    public Task<Customer?> GetWithAuthByIdAsync(Guid id);
    public Task<Customer?> GetByPhoneNumberAsync(string phone);
    public Task<Customer?> GetByAuthIdAsync(Guid id);
    public Task<IEnumerable<Customer>> GetAllWithAuthAsync();
    public Task<bool> IsActiveAsync(Guid id);
}
