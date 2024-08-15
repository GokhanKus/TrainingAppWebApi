using Entities.Models;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
	{
		public WorkoutRepository(RepositoryContext context) : base(context)
		{
		}

		public Task AddWorkoutAsync(int userId, Workout workout)
		{
			throw new NotImplementedException();
		}

		public void DeleteWorkout(int userId, Workout workout)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Workout>> GetAllWorkoutsByUserIdAsync(int userId, bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public Task<Workout> GetOneWorkoutByUserIdAsync(int userId, bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public void UpdateWorkout(int userId, Workout workout)
		{
			throw new NotImplementedException();
		}
	}
}
