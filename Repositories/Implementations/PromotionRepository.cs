using System;
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

    public async Task UpdatePromotionActivation(long id, bool isActive)
    {
        var promotion = await _context.Promotions.FirstOrDefaultAsync(x => x.Id == id);
        if (promotion != null)
        {
            promotion.IsActive = isActive;
            await _context.SaveChangesAsync();
        }
    }
}
