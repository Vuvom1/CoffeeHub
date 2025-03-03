using System;
using System.Linq.Expressions;
using CoffeeHub.Services.Interfaces;
using CoffeeHub.Repositories.Interfaces;


namespace CoffeeHub.Services.Implementations;

public class BaseService<T> : IBaseService<T> where T : CoffeeHub.Models.BaseEntity
{
    protected readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }
    public async Task<T> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.FindAsync(predicate);  
    }

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        await _repository.DeleteAsync(entity);
    }
    
}
