
using Entities.DTOs.BodyMeasurement;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.ServiceConcretes
{
	public interface IWorkoutService
	{
		Task<IEnumerable<Workout>?> GetAllWorkoutByUserIdAsync(WorkoutParameters workoutParameters, string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutWithExercises(int id, string userId);
		Task AddOneWorkoutAsync(string userId, WorkoutDtoForInsertion workoutDto);
		//Task UpdateOneWorkoutAsync(string userId, WorkoutDtoForUpdate workoutDto, bool trackChanges);
		Task DeleteOneWorkoutAsync(int id, string userId, bool trackChanges);
	}
}
