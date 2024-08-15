using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IExerciseCategoryRepository
	{
		Task<IEnumerable<ExerciseCategory>> GetAllExerciseCategoriesAsync(bool trackChanges);
		Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges);
		Task<ExerciseCategory?> GetOneExerciseCategoryWithExercises(int id);
		Task AddOneExerciseCategory(ExerciseCategory exerciseCategory);
		void UpdateOneExerciseCategory(ExerciseCategory exerciseCategory);
		void DeleteOneExerciseCategory(ExerciseCategory exerciseCategory);
	}
}
