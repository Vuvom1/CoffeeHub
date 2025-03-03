using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IPromotionRepository : IBaseRepository<Promotion>
{
    Task<Promotion?> GetByCodeAsync(string code);
    Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    Task UpdatePromotionActivation(long id, bool isActive);
}
