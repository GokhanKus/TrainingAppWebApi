using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.RepoConcretes
{
	public interface IExerciseRepository
	{
		Task<IEnumerable<Exercise>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges);
		Task<Exercise?> GetOneExerciseByIdAsync(int id, bool trackChanges);
		Task<Exercise?> GetOneExerciseWithCategoryAsync(int id);
		Task AddOneExerciseAsync(Exercise exercise);
		void UpdateOneExercise(Exercise exercise);
		void DeleteOneExercise(Exercise exercise);
	}
}
