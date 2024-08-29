using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Repositories.RepoConcretes;

namespace Repositories.MemoryCachedRepos
{
    public sealed class CachedWorkoutRepository : IWorkoutRepository
    {
        private readonly IWorkoutRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        public CachedWorkoutRepository(IWorkoutRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task AddWorkoutAsync(string userId, Workout workout)
        {
            workout.UserId = userId;
            await _decorated.AddWorkoutAsync(userId, workout);

            _memoryCache.Remove($"AllWorkoutsByUserId_{userId}");
        }

        public void DeleteWorkout(string userId, Workout workout)
        {
            workout.UserId = userId;
            _decorated.DeleteWorkout(userId, workout);

            _memoryCache.Remove($"AllWorkoutsByUserId_{userId}");
            _memoryCache.Remove($"WorkoutByUserId_{userId}_{workout.Id}");
            _memoryCache.Remove($"WorkoutWithExercises{userId}_{workout.Id}");
        }

        public async Task<IEnumerable<Workout>?> GetAllWorkoutsByUserIdAsync(string userId, bool trackChanges)
        {
            var cacheKey = $"AllWorkoutsByUserId_{userId}";
            var workouts = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetAllWorkoutsByUserIdAsync(userId, trackChanges);
            });
            return workouts;
        }

        public async Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges)
        {
            var cacheKey = $"WorkoutByUserId_{userId}_{id}";
            var workout = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetOneWorkoutByUserIdAsync(id, userId, trackChanges);
            });
            return workout;
        }

        public async Task<Workout?> GetOneWorkoutWithExercises(int id, string userId)
        {
            var cacheKey = $"WorkoutWithExercises{userId}_{id}";
            var workoutWithExercises = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetOneWorkoutWithExercises(id, userId);
            });
            return workoutWithExercises;
        }

        public void UpdateWorkout(string userId, Workout workout)
        {
            workout.UserId = userId;
            _decorated.UpdateWorkout(userId, workout);

            _memoryCache.Remove($"AllWorkoutsByUserId_{userId}");
            _memoryCache.Remove($"WorkoutByUserId_{userId}_{workout.Id}");
            _memoryCache.Remove($"WorkoutWithExercises{userId}_{workout.Id}");
        }
    }
}
