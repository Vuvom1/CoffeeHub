using System;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IPromotionRepository : IBaseRepository<Promotion>
{
    Task<Promotion?> GetByCodeAsync(string code);
    Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    Task<IEnumerable<Promotion>> GetPromotionsByCustomerLevelAsync(CustomerLevel customerLevel);
    Task UpdatePromotionActivation(Guid id, bool isActive);
    Task<decimal> CalculateDiscountAsync(Guid promotionId, decimal totalAmount);
    Task<int> IncreaseUsageCountAsync(Guid promotionId);
    Task<int> DecreaseUsageCount(Guid promotionId);
    Task<int> GetUsageCountAsync(Guid promotionId);
    Task<bool> IsPromotionExpiredAsync(Guid promotionId);
    Task<bool> IsPromotionActiveAsync(Guid promotionId);
    Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount);
    Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount, DateTime usageDate);
    Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount, DateTime usageDate, CustomerLevel customerLevel);
    Task<bool> IsExistCodeAsync(string code);
    Task<bool> IsExistNameAsync(string name);
    Task UpdateActivationAsync(Guid promotionId, bool isActive);

}
