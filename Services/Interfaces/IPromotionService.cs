using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IPromotionService : IBaseService<Promotion>
{
    Task<Promotion?> GetByCodeAsync(string code);
    Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    Task<IEnumerable<Promotion>> GetUsablePromotionsByCustomerIdAsync(Guid customerId);
    Task UpdateActivationAsync(Guid id, bool isActive);
}
