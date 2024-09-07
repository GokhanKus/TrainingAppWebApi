using Entities.Models;
using Entities.RequestFeatures;
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

		public async Task<PagedList<Workout>?> GetAllWorkoutsByUserIdAsync(WorkoutParameters workoutParameters, string userId, bool trackChanges)
		{
			var allWorkouts = await GetAllByConditionAsync(w => w.UserId == userId, trackChanges);
			return PagedList<Workout>.ToPagedList(allWorkouts, workoutParameters.PageNumber, workoutParameters.PageSize);
			//return await GetAllByConditionAsync(w => w.UserId == userId, trackChanges);
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

		public async Task<int> WorkoutCountAsync(string userId)
		{
			var workoutCount = await CountAsync(w => w.UserId == userId);
			return workoutCount;
		}
	}
}
