using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IPromotionService : IBaseService<Promotion>
{
    Task<Promotion?> GetByCodeAsync(string code);
    Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    Task UpdatePromotionActivation(long id, bool isActive);
}
