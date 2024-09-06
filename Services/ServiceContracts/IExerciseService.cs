using Entities.DTOs.Exercise;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.ServiceConcretes
{
	public interface IExerciseService
	{
		Task<IEnumerable<Exercise>?> GetAllExercisesAsync(ExerciseParameters exercise, bool trackChanges);
		Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges);
		Task<Exercise> GetOneExerciseWithCategoryAsync(int id);
		Task<Exercise> AddExerciseAsync(ExerciseDtoForInsertion exerciseDto);
		Task UpdateExerciseAsync(ExerciseDtoForUpdate exerciseDto, bool trackChanges);
		Task DeleteExerciseAsync(int id, bool trackChanges);
	}
}
