using System.Linq.Expressions;

namespace Repositories.RepoBases
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges);
		Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges);
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
	}
}
