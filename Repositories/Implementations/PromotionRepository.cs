using System;
using CoffeeHub.Enums;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class PromotionRepository : BaseRepository<Promotion>, IPromotionRepository
{
    private new CoffeeHubContext _context;
    public PromotionRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public Task<decimal> CalculateDiscountAsync(Guid promotionId, decimal totalAmount)
    {
        return Task.FromResult(_context.Promotions.FirstOrDefault(x => x.Id == promotionId)?.DiscountRate * totalAmount / 100 ?? 0);
    }

    public Task<int> DecreaseUsageCount(Guid promotionId)
    {
        var promotion = _context.Promotions.FirstOrDefault(x => x.Id == promotionId);
        if (promotion != null)
        {
            promotion.UssageCount--;
            _context.SaveChanges();
            return Task.FromResult(promotion.UssageCount ?? 0);
        }
        return Task.FromResult(0);
    }

    public Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
    {
        var promotions = _context.Promotions.Where(x => x.IsActive);
        return Task.FromResult(promotions.ToList().AsEnumerable());
    }

    public Task<Promotion?> GetByCodeAsync(string code)
    {
        var promotion = _context.Promotions.FirstOrDefaultAsync(x => x.Code == code);
        return promotion;
    }

    public Task<IEnumerable<Promotion>> GetPromotionsByCustomerLevelAsync(CustomerLevel customerLevel)
    {
        var promotions = _context.Promotions.Where(x => x.CustomerLevel == customerLevel);

        return Task.FromResult(promotions.ToList().AsEnumerable());
    }

    public Task<int> GetUsageCountAsync(Guid promotionId)
    {
        return Task.FromResult(_context.Promotions.FirstOrDefault(x => x.Id == promotionId)?.UssageCount ?? 0);
    }

    public Task<int> IncreaseUsageCountAsync(Guid promotionId)
    {
        var promotion = _context.Promotions.FirstOrDefault(x => x.Id == promotionId);
        if (promotion != null)
        {
            promotion.UssageCount++;
            _context.SaveChangesAsync();
            return Task.FromResult(promotion.UssageCount ?? 0);
        }
        return Task.FromResult(0);
    }

    public Task<bool> IsExistCodeAsync(string code)
    {
        return Task.FromResult(_context.Promotions.Any(x => x.Code == code));
    }

    public Task<bool> IsExistNameAsync(string name)
    {
        return Task.FromResult(_context.Promotions.Any(x => x.Name == name));
    }

    public Task<bool> IsPromotionActiveAsync(Guid promotionId)
    {
        return Task.FromResult(_context.Promotions.FirstOrDefault(x => x.Id == promotionId)?.IsActive ?? false);
    }

    public async Task<bool> IsPromotionExpiredAsync(Guid promotionId)
    {
        var promotion = _context.Promotions.FirstOrDefault(x => x.Id == promotionId);
        if (promotion != null)
        {
            return await Task.FromResult(promotion.EndDate < DateTime.Now);
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount)
    {
        return await Task.FromResult(_context.Promotions.FirstOrDefault(x => x.Id == promotionId)?.MinPurchaseAmount <= totalAmount);
    }

    public async Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount, DateTime usageDate)
    {
        return await Task.FromResult(_context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.MinPurchaseAmount <= totalAmount && _context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.StartDate <= usageDate && _context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.EndDate >= usageDate);
    }

    public async Task<bool> IsPromotionUsableAsync(Guid promotionId, decimal totalAmount, DateTime usageDate, CustomerLevel customerLevel)
    {
        return await Task.FromResult(_context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.MinPurchaseAmount <= totalAmount && _context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.StartDate <= usageDate && _context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.EndDate >= usageDate && _context.Promotions
        .FirstOrDefault(x => x.Id == promotionId)?.CustomerLevel == customerLevel);
    }

    public Task UpdateActivationAsync(Guid promotionId, bool isActive)
    {
        var promotion = _context.Promotions.FirstOrDefault(x => x.Id == promotionId);
        if (promotion != null)
        {
            promotion.IsActive = isActive;
            _context.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }

    public async Task UpdatePromotionActivation(Guid id, bool isActive)
    {
        var promotion = await _context.Promotions.FirstOrDefaultAsync(x => x.Id == id);
        if (promotion != null)
        {
            promotion.IsActive = isActive;
            await _context.SaveChangesAsync();
        }
    }

    
}
