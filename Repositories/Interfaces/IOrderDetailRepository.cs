using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
{
    Task<decimal> CalculateTotalPriceAsync(Guid menuItemId, int quantity);
    Task AddManyAsync(IEnumerable<OrderDetail> orderDetails);
}
