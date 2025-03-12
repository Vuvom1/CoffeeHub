using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Services.Interfaces;

public interface IIngredientService : IBaseService<Ingredient>
{
    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids);
}
