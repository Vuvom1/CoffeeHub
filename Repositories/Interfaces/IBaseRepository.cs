using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoffeeHub.Models;

namespace CoffeeHub.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
