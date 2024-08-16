using Entities.DTOs.Exercise;
using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IExerciseService
	{
		Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges);
		Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges);
		Task<Exercise> GetOneExerciseWithCategoryAsync(int id);
		Task<Exercise> AddExerciseAsync(ExerciseDtoForInsertion exercise);
		Task UpdateExerciseAsync(ExerciseDtoForUpdate exercise, bool trackChanges);
		Task DeleteExerciseAsync(int id, bool trackChanges);
	}
}
