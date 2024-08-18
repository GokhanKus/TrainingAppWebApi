using Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using System.Linq.Expressions;

namespace Repositories.RepoBases
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
	{
		protected readonly RepositoryContext _context;
		protected readonly DbSet<TEntity> _dbSet;
		protected BaseRepository(RepositoryContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}
		public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
		public void Delete(TEntity entity) => _dbSet.Remove(entity);
		public void Update(TEntity entity) => _dbSet.Update(entity);
		public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges)
		{
			return trackChanges
		   ? await _dbSet.OrderBy(e => e.Id).ToListAsync()
		   : await _dbSet.AsNoTracking().OrderBy(e => e.Id).ToListAsync();
		}
		public async Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges)
		{
			return trackChanges
				? await _dbSet.FirstOrDefaultAsync(expression)
				: await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
		}
		public async Task<IEnumerable<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges)
		{
			return trackChanges
				? await _dbSet.Where(expression).ToListAsync()
				: await _dbSet.AsNoTracking().Where(expression).ToListAsync();
		}
	}
}
