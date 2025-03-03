using System;
using System.Linq.Expressions;

namespace CoffeeHub.Services.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
