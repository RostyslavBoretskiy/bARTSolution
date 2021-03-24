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

        IEnumerable<TEntity> Get();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        Task<bool> RemoveAsync(TEntity item);
        Task<bool> RemoveAsync(object key);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items);

        Task<bool> UpdateAsync(TEntity item);

        IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
