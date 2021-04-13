using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Data.Core
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<bool> CreateRangeAsync(IEnumerable<TEntity> items);

        Task<TEntity> FindAsync(object key, params string[] paths);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        Task<bool> RemoveAsync(TEntity item);
        Task<bool> RemoveAsync(object key);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items);

        Task<bool> UpdateAsync(TEntity item);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = true);
        Task<IEnumerable<TEntity>> GetWithIncludeAsync<TProperty>(Expression<Func<TEntity, object>> selector, params Expression<Func<object, TProperty>>[] include);
        Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
