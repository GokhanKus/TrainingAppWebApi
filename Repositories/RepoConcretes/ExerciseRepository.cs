using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
	{
		public ExerciseRepository(RepositoryContext context) : base(context) { }

		public async Task AddOneExerciseAsync(Exercise exercise) => await AddAsync(exercise);
		public void DeleteOneExercise(Exercise exercise) => Delete(exercise);
		public void UpdateOneExercise(Exercise exercise) => Update(exercise);
		public async Task<IEnumerable<Exercise>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges)
		{
			return await GetAllAsync(trackChanges);
		}
		public async Task<Exercise?> GetOneExerciseByIdAsync(int id, bool trackChanges)
		{
			return await GetByConditionAsync(e => e.Id.Equals(id), trackChanges);
		}
		public async Task<Exercise?> GetOneExerciseWithCategoryAsync(int id)
		{
			return await _dbSet.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<int> ExerciseCountAsync()
		{
			var exerciseCount = await CountAsync();
			return exerciseCount;
		}
	}
}
