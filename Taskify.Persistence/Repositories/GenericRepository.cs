using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;
using Taskify.Persistence.Context;

namespace Taskify.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TaskifyDbContext _context;
        private readonly DbSet<T> _dbSet;
        protected GenericRepository(TaskifyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T[]> AddRangeAsync(T[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;

        }

        public Task<IEnumerable<T>> Count(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public  Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        private IQueryable<T> ApplyIncludes(IQueryable<T> query, ISpecification<T> specification)
        {
            return specification.Includes
                                .Aggregate(query, (current, include) => current.Include(include));
        }

        public async Task<IEnumerable<T>> SelectManyAsync(ISpecification<T> specification)
        {
            var query = _context.Set<T>().AsQueryable();
            var includes = ApplyIncludes(query, specification);
            return await includes
                        .Where(specification.Predicate)
                        .AsNoTracking()
                        .ToListAsync(); 
        }

        public async Task<IEnumerable<T>> SelectManyPaginatedAsync(ISpecification<T> specification, int pageSize = 10, int currentPage=1)
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

        public Task<T?> SelectOneAsync(ISpecification<T> specification)
        {
            var query = _context.Set<T>().AsQueryable();
            var includes = ApplyIncludes(query, specification);
            return includes.FirstOrDefaultAsync(specification.Predicate);
        }

        public  Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }
    }
}
