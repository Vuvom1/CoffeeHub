using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private new readonly CoffeeHubContext _dbContext;
    public CustomerRepository(CoffeeHubContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task DecreasePointAsync(Guid id, int point)
    {
        await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id).ContinueWith(t =>
        {
            if (t.Result == null)
            {
                throw new InvalidOperationException($"Customer with id {id} not found.");
            }
            t.Result.Point -= point;
            _dbContext.Customers.Update(t.Result);
        });
    }

    public async Task<IEnumerable<Customer>> GetAllWithAuthAsync()
    {
        return await _dbContext.Customers.Include(c => c.Auth).ToListAsync();
    }

    public Task<Customer?> GetByAuthIdAsync(Guid id)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(c => c.AuthId == id);
    }

    public Task<Customer?> GetByEmailAsync(string email)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(c => c.Auth.Email == email);
    }

    public Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }

    public Task<Customer?> GetWithAuthByIdAsync(Guid id)
    {
        return _dbContext.Customers.Include(c => c.Auth).FirstOrDefaultAsync(c => c.Id == id);
    }


    public Task<bool> IsActiveAsync(Guid id)
    {
        return _dbContext.Customers.AnyAsync(c => c.Id == id && c.Auth.IsAvailable == true);
    }

    public Task UpdateActivationAsync(Guid id, bool isActive)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id).ContinueWith(t =>
        {
            if (t.Result == null)
            {
                throw new InvalidOperationException($"Customer with id {id} not found.");
            }
            t.Result.Auth.IsAvailable = isActive;
            _dbContext.Customers.Update(t.Result);
        });
    }
}
