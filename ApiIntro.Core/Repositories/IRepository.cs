﻿using System.Linq.Expressions;

namespace ApiIntro.Core.Repositories.Interfaces
{
    public interface IRepository<T>
    {

        public Task AddAsync(T entity);
        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression,params string[] includes );

        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes);

        public Task Update(T entity);

        public Task Remove(T entity);

        public Task<int> SaveAsync();

        public int Save();

        public Task<bool> IsExsist(Expression<Func<T, bool>> expression);
    }
}
