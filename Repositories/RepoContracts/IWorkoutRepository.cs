using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IWorkoutRepository
	{
		Task<IEnumerable<Workout>> GetAllWorkoutsByUserIdAsync(int userId, bool trackChanges);
		Task<Workout> GetOneWorkoutByUserIdAsync(int userId, bool trackChanges);
		Task AddWorkoutAsync(int userId, Workout workout);
		void UpdateWorkout(int userId, Workout workout);
		void DeleteWorkout(int userId, Workout workout);
	}
}
