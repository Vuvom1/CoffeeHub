using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class CustomerRepository(CoffeeHubContext dbContext) : BaseRepository<Customer>(dbContext), ICustomerRepository
{
    public async Task DecreasePointAsync(Guid id, int point)
    {
        await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id).ContinueWith(t =>
        {
            if (t.Result == null)
            {
                throw new InvalidOperationException($"Customer with id {id} not found.");
            }
            t.Result.Point -= point;
            dbContext.Customers.Update(t.Result);
        });
    }

    public async Task<IEnumerable<Customer>> GetAllWithAuthAsync()
    {
        return await dbContext.Customers.Include(c => c.Auth).ToListAsync();
    }

    public Task<Customer?> GetByEmailAsync(string email)
    {
        return dbContext.Customers.FirstOrDefaultAsync(c => c.Auth.Email == email);
    }

    public Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
    {
        return dbContext.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }

    public Task<Customer?> GetWithAuthByIdAsync(Guid id)
    {
        return dbContext.Customers.Include(c => c.Auth).FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task IncreasePointAsync(Guid id, int point)
    {
        return dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id).ContinueWith(t =>
        {
            if (t.Result == null)
            {
                throw new InvalidOperationException($"Customer with id {id} not found.");
            }
            t.Result.Point += point;
            dbContext.Customers.Update(t.Result);
        });
    }

    public Task<bool> IsActiveAsync(Guid id)
    {
        return dbContext.Customers.AnyAsync(c => c.Id == id && c.Auth.IsAvailable == true);
    }

    public Task UpdateActivationAsync(Guid id, bool isActive)
    {
        return dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id).ContinueWith(t =>
        {
            if (t.Result == null)
            {
                throw new InvalidOperationException($"Customer with id {id} not found.");
            }
            t.Result.Auth.IsAvailable = isActive;
            dbContext.Customers.Update(t.Result);
        });
    }
}
