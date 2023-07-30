
using ApiIntro.Core.Repositories.Interfaces;
using ApiIntro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiIntro.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiIntroDbContext _context;

        public Repository(ApiIntroDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query= _context.Set<T>().Where(expression);
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {

            var query = _context.Set<T>().Where(expression);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }


            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> IsExsist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).Count() > 0;
        }

        public async Task Remove(T entity)
        {
            _context.Remove(entity);
        }

        public  int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
