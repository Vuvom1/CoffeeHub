using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class CustomerService : BaseService<Customer>, ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAuthRepository _authRepository;
    public CustomerService(ICustomerRepository customerRepository, IAuthRepository authRepository) : base(customerRepository)
    {
        _customerRepository = customerRepository;
        _authRepository = authRepository;
    }

    public async Task<Customer> AddWithAuthAsync(Customer customer, Guid authId)
    {
        var addedCustomer = await _customerRepository.AddAndReturnAsync(customer);
        var auth = await _authRepository.GetByIdAsync(authId);
        
        if (auth == null)
        {
            throw new Exception("Auth not found");
        }

        await _authRepository.UpdateAsync(auth);

        return addedCustomer;
    }

    public Task<IEnumerable<Customer>> GetAllWithAuthAsync()
    {
        return _customerRepository.GetAllWithAuthAsync();
    }

    public Task<Customer?> GetByAuthIdAsync(Guid id)
    {
        return _customerRepository.GetByAuthIdAsync(id);
    }

    public Task<Customer?> GetByPhoneNumberAsync(string phone)
    {
        return _customerRepository.GetByPhoneNumberAsync(phone);
    }

    public Task<Customer?> GetWithAuthByIdAsync(Guid id)
    {
        return _customerRepository.GetWithAuthByIdAsync(id);
    }

    public Task<bool> IsActiveAsync(Guid id)
    {
        return _customerRepository.IsActiveAsync(id);
    }
}
