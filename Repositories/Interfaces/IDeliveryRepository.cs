using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IDeliveryRepository: IBaseRepository<Delivery>
{
    Task<Delivery?> GetWithOrderAsync(Guid id);
}
