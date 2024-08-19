using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
	{
		public WorkoutRepository(RepositoryContext context) : base(context)
		{
		}

		public async Task AddWorkoutAsync(string userId, Workout workout)
		{
			workout.UserId = userId;
			await AddAsync(workout);
		}

		public void DeleteWorkout(string userId, Workout workout)
		{
			workout.UserId = userId;
			Delete(workout);
		}

		public async Task<IEnumerable<Workout>> GetAllWorkoutsByUserIdAsync(string userId, bool trackChanges)
		{
			return await GetAllByConditionAsync(w => w.UserId == userId, trackChanges);
		}

		public async Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges)
		{
			return await GetByConditionAsync(w => w.Id == id && w.UserId == userId, trackChanges);
		}

		public async Task<Workout?> GetOneWorkoutWithExercises(int id, string userId)
		{
			return await _dbSet.Include(w => w.WorkoutExercises).ThenInclude(we => we.Exercise).FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);
		}

		public void UpdateWorkout(string userId, Workout workout)
		{
			workout.UserId = userId;
			Update(workout);
		}
	}
}
