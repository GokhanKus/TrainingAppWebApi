
using Entities.DTOs.Exercise;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IExerciseCategoryService
	{
		Task<IEnumerable<ExerciseCategory>> GetAllExercisesCategoriesAsync(bool trackChanges);
		Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges);
		Task<ExerciseCategory?> GetOneExerciseCategoryWithExercisesAsync(int id);
		Task<ExerciseCategory> AddExerciseCategoryAsync(ExerciseCategoryDtoForInsertion exerciseCategoryDto);
		Task UpdateExerciseCategoryAsync(WorkoutDtoForUpdate exerciseCategoryDto, bool trackChanges);
		Task DeleteExerciseCategoryAsync(int id, bool trackChanges);
	}
}
