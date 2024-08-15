using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class ExerciseCategoryRepository : BaseRepository<ExerciseCategory>, IExerciseCategoryRepository
	{
		public ExerciseCategoryRepository(RepositoryContext context) : base(context) {}
		public async Task AddOneExerciseCategory(ExerciseCategory exerciseCategory) => await AddAsync(exerciseCategory);
		public void DeleteOneExerciseCategory(ExerciseCategory exerciseCategory) => Delete(exerciseCategory);
		public void UpdateOneExerciseCategory(ExerciseCategory exerciseCategory) => Update(exerciseCategory);
		public async Task<IEnumerable<ExerciseCategory>> GetAllExerciseCategoriesAsync(bool trackChanges)
		{
			return await GetAllAsync(trackChanges);
		}
		public async Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges)
		{
			return await GetByConditionAsync(ec => ec.Id.Equals(id), trackChanges);
		}
		public async Task<ExerciseCategory?> GetOneExerciseCategoryWithExercises(int id)
		{
			return await _dbSet.Include(ec => ec.Exercises).FirstOrDefaultAsync(ec => ec.Id.Equals(id));
		}
	}
}
