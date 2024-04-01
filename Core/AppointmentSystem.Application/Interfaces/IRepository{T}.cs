﻿using System.Linq.Expressions;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(List<Expression<Func<T, object>>>? includes = null);
        Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>>? includes = null);
        Task<T?> GetById(object id, List<Expression<Func<T, object>>>? includes = null);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
