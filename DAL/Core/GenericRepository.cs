using bARTSolution.Domain.Data.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Data.Core
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext context;
		private readonly DbSet<TEntity> dbSet;

		public GenericRepository(ApplicationDbContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public async Task<TEntity> FindAsync(object key)
		{
			return await dbSet.FindAsync(key);
		}

		public IEnumerable<TEntity> Get()
		{
			return dbSet
				.AsNoTracking();
		}
		public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
		{
			return dbSet
				.AsNoTracking()
				.Where(predicate)
				.AsQueryable();
		}

		public async Task<TEntity> CreateAsync(TEntity item)
		{
			var result = await this.dbSet.AddAsync(item);
			await TrySaveChangesAsync();

			return result.Entity;
		}
		public async Task<bool> CreateRangeAsync(IEnumerable<TEntity> items)
		{
			await this.dbSet.AddRangeAsync(items);
			return await TrySaveChangesAsync();
		}

		public async Task<bool> UpdateAsync(TEntity item)
		{
			context.Entry(item).State = EntityState.Modified;
			return await TrySaveChangesAsync();
		}

		public async Task<bool> RemoveAsync(TEntity item)
		{
			dbSet.Remove(item);
			return await TrySaveChangesAsync();
		}
		public async Task<bool> RemoveAsync(object key)
		{
			var entity = await FindAsync(key);
			dbSet.Remove(entity);

			return await TrySaveChangesAsync();
		}
		public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items)
		{
			dbSet.RemoveRange(items);

			return await TrySaveChangesAsync();
		}

		public IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties);
		}
		public IQueryable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var query = Include(includeProperties);

			return query
				.Where(predicate)
				.AsQueryable();
		}

		private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = dbSet.AsNoTracking();
			return includeProperties
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		private async Task<bool> TrySaveChangesAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}
	}
}
