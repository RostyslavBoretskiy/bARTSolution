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

        Task<TEntity> FindAsync(object key);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        Task<bool> RemoveAsync(TEntity item);
        Task<bool> RemoveAsync(object key);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items);

        Task<bool> UpdateAsync(TEntity item);

        Task<IQueryable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IQueryable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
