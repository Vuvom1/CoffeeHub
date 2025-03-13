using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class PromotionService : BaseService<Promotion>, IPromotionService
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly ICustomerRepository _customerRepository;
    
    public PromotionService(IPromotionRepository promotionRepository, ICustomerRepository customerRepository) : base(promotionRepository)
    {
        _promotionRepository = promotionRepository;
        _customerRepository = customerRepository;
    }

    public Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
    {
        return _promotionRepository.GetActivePromotionsAsync();
    }

    public Task<Promotion?> GetByCodeAsync(string code)
    {
        return _promotionRepository.GetByCodeAsync(code);
    }

    public Task<IEnumerable<Promotion>> GetUsablePromotionsByCustomerIdAsync(Guid customerId)
    {
        var customer = _customerRepository.GetByIdAsync(customerId).Result;
        if (customer == null)
        {
            throw new InvalidOperationException($"Customer with id {customerId} not found.");
        }
        
        return _promotionRepository.GetUsablePromotionsByCustomerLevelAsync(customer.CustomerLevel);
    }

    public Task UpdateActivationAsync(Guid id, bool isActive)
    {
        return _promotionRepository.UpdatePromotionActivation(id, isActive);
    }

    public override Task AddAsync(Promotion promotion)
    {
        if (!IsValidStartDateAndEndDate(promotion.StartDate, promotion.EndDate).Result)
        {
            throw new InvalidOperationException("Start date must be less than end date and greater than current date.");
        }
        
        if (!IsValidMaxDiscountAmount(promotion.MaxDiscountAmount, promotion.MinPurchaseAmount).Result)
        {
            throw new InvalidOperationException("Max discount amount must be less than or equal to min purchase amount.");
        }

        if (_promotionRepository.IsExistCodeAsync(promotion.Code).Result)
        {
            throw new InvalidOperationException($"Promotion with code {promotion.Code} already exists.");
        }

        if (_promotionRepository.IsExistNameAsync(promotion.Name).Result)
        {
            throw new InvalidOperationException($"Promotion with name {promotion.Name} already exists.");
        }

        return base.AddAsync(promotion);
    }

    private static Task<bool> IsValidStartDateAndEndDate(DateTime startDate, DateTime endDate)
    {
        bool isValid = startDate < endDate || startDate > DateTime.Now;
        return Task.FromResult(isValid);
    }

    private static Task<bool> IsValidMaxDiscountAmount(decimal maxDiscountAmount, decimal MinPurchaseAmount)
    {
        bool isValid = maxDiscountAmount <= MinPurchaseAmount;
        return Task.FromResult(isValid);
    }

}
