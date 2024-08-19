
using Entities.DTOs.BodyMeasurement;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IWorkoutService
	{
		Task<IEnumerable<Workout>> GetAllWorkoutByUserIdAsync(string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutWithExercises(int id, string userId);
		Task AddOneWorkoutAsync(string userId, WorkoutDtoForInsertion workoutDto);
		Task UpdateOneWorkoutAsync(string userId, WorkoutDtoForUpdate workoutDto, bool trackChanges);
		Task DeleteOneWorkoutAsync(int id, string userId, bool trackChanges);
	}
}
