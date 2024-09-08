using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.SeedWorks
{
    public interface IGenericRepository<T> where T : class
    {
        #region Mutation
        Task<T> AddAsync(T entity);
        Task<T[]> AddRangeAsync(T[] entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entities);
        #endregion
        #region Query
        Task<T?> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>>? predicate = null);
        Task<T?> SelectOneAsync(ISpecification<T> specification);
        Task<IEnumerable<T>> SelectManyAsync(ISpecification<T> specification);
        Task<IEnumerable<T>> SelectManyPaginatedAsync(ISpecification<T> specification, int pageSize = 10, int pageIndex = 0);
        Task<IEnumerable<T>> Count(ISpecification<T> specification);
        #endregion

    }
}
