using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;
using Taskify.Persistence.Context;

namespace Taskify.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TaskifyDbContext _context;
        private readonly DbSet<T> _dbSet;
        protected GenericRepository(TaskifyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T[]> AddRangeAsync(T[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;

        }

        public virtual Task<IEnumerable<T>> Count(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            var query = _dbSet.AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.AsQueryable();
            
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        private IQueryable<T> ApplyIncludes(IQueryable<T> query, ISpecification<T> specification)
        {
            query = specification.Includes
                                  .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                                  .Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public virtual async Task<IEnumerable<T>> SelectManyAsync(ISpecification<T> specification)
        {
            var query = _context.Set<T>().AsQueryable();
            var includes = ApplyIncludes(query, specification);
            return await includes
                        .Where(specification.Predicate)
                        .AsNoTracking()
                        .ToListAsync(); 
        }

        public virtual async Task<IEnumerable<T>> SelectManyPaginatedAsync(ISpecification<T> specification, int pageSize = 10, int currentPage=1)
        {
            int skip = (currentPage -1) * pageSize;
            var query = _context.Set<T>().AsQueryable();
            var includes = ApplyIncludes(query, specification);
            return await includes
                         .Where(specification.Predicate)
                         .AsNoTracking().Skip(skip)
                         .Take(pageSize)
                         .ToListAsync();
        }

        public virtual IQueryable<T> SelectOne(ISpecification<T> specification)
        {
            var query = _context.Set<T>().AsQueryable();
            var includes = ApplyIncludes(query, specification);
            return includes.Where(specification.Predicate);
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual Task DeleteRangeAsync(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }
    }
}
