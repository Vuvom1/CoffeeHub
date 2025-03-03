using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class PromotionService : BaseService<Promotion>, IPromotionService
{
    private readonly IPromotionRepository _promotionRepository;
    
    public PromotionService(IPromotionRepository promotionRepository) : base(promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
    {
        return _promotionRepository.GetActivePromotionsAsync();
    }

    public Task<Promotion?> GetByCodeAsync(string code)
    {
        return _promotionRepository.GetByCodeAsync(code);
    }

    public Task UpdatePromotionActivation(long id, bool isActive)
    {
        return _promotionRepository.UpdatePromotionActivation(id, isActive);
    }
}
