using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IWorkoutRepository
	{
		Task<IEnumerable<Workout>> GetAllWorkoutsByUserIdAsync(string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges);
		Task<Workout?> GetOneWorkoutWithExercises(int id, string userId);
		Task AddWorkoutAsync(string userId, Workout workout);
		void UpdateWorkout(string userId, Workout workout);
		void DeleteWorkout(string userId, Workout workout);
	}
}
