using bARTSolution.Domain.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

		public async Task<TEntity> FindAsync(object key, params string[] paths)
		{
			var model = await dbSet.FindAsync(key);

			foreach(var path in paths)
            {
				await context.Entry(model).Reference(path).LoadAsync();
            }

			return model;
		}

		public async Task<IEnumerable<TEntity>> GetAsync()
		{
			return await dbSet
				.AsNoTracking()
				.ToListAsync();
		}
		public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
		{
			return await dbSet
				.AsNoTracking()
				.Where(predicate)
				.ToAsyncEnumerable()
				.ToListAsync();
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
			var entity = await dbSet.FindAsync(key);
			dbSet.Remove(entity);

			return await TrySaveChangesAsync();
		}
		public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> items)
		{
			dbSet.RemoveRange(items);

			return await TrySaveChangesAsync();
		}

		public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return await IncludeAsync(includeProperties);
		}
		public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var query = await IncludeAsync(includeProperties);

			return query
				.Where(predicate);
		}
		public async Task<IEnumerable<TEntity>> GetWithIncludeAsync<TProperty>(Expression<Func<TEntity, object>> selector, params Expression<Func<object, TProperty>>[] include)
		{
			var query = await ThenIncludeAsync(selector, include);

			return query;
		}
		public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
										  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
										  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
										  bool disableTracking = true)
		{
			IQueryable<TEntity> query = dbSet;
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}
			if (include != null)
			{
				query = include(query);
			}
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (orderBy != null)
			{
				return orderBy(query);
			}
			else
			{
				return query;
			}
		}

		private async Task<IEnumerable<TEntity>> IncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = dbSet.AsNoTracking();

			return await includeProperties
				.ToAsyncEnumerable()
				.AggregateAsync(query, (current, includeProperty) => current.Include(includeProperty));
		}

		private async Task<IEnumerable<TEntity>> ThenIncludeAsync<TProperty>(Expression<Func<TEntity, object>> selector, params Expression<Func<object, TProperty>>[] include)
		{
			var query = dbSet.AsNoTracking().Include(selector);

			foreach (var i in include)
				query.ThenInclude(i);

			return await query.ToListAsync();
		}

		private async Task<bool> TrySaveChangesAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}
	}
}
