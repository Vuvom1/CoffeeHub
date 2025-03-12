using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Repositories.Interfaces;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    new Task<IEnumerable<Ingredient>> GetAllAsync();
    public Task<List<Ingredient>> GetByIdsAsync(IEnumerable<Guid> ids);
}
