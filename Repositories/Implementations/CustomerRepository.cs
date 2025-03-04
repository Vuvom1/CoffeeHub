using System;
using CoffeeHub.Models;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class CustomerRepository(CoffeeHubContext dbContext) : BaseRepository<Customer>(dbContext), ICustomerRepository
{
    
}
