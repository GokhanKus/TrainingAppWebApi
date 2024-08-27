using Entities.DTOs.Exercise;
using Entities.Models;

namespace Services.ServiceConcretes
{
	public interface IExerciseService
	{
		Task<IEnumerable<Exercise>?> GetAllExercisesAsync(bool trackChanges);
		Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges);
		Task<Exercise> GetOneExerciseWithCategoryAsync(int id);
		Task<Exercise> AddExerciseAsync(ExerciseDtoForInsertion exerciseDto);
		Task UpdateExerciseAsync(ExerciseDtoForUpdate exerciseDto, bool trackChanges);
		Task DeleteExerciseAsync(int id, bool trackChanges);
	}
}
