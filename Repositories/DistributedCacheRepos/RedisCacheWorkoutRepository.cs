using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.RepoConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DistributedCacheRepos
{
	public class RedisCacheWorkoutRepository : IWorkoutRepository
	{
		private readonly IWorkoutRepository _decorated;
		private readonly IDistributedCache _redisCache;
		public RedisCacheWorkoutRepository(IWorkoutRepository decorated, IDistributedCache redisCache)
		{
			_decorated = decorated;
			_redisCache = redisCache;
		}

		public async Task AddWorkoutAsync(string userId, Workout workout)
		{
			await _decorated.AddWorkoutAsync(userId, workout);

			var listCacheKey = $"AllWorkoutsByUserId_{userId}";
			await _redisCache.RemoveAsync(listCacheKey);
		}

		public async Task<IEnumerable<Workout>?> GetAllWorkoutsByUserIdAsync(string userId, bool trackChanges)
		{
			var listCacheKey = $"AllWorkoutsByUserId_{userId}";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			IEnumerable<Workout>? workouts;
			if (string.IsNullOrEmpty(cachedData))
			{
				workouts = await _decorated.GetAllWorkoutsByUserIdAsync(userId, trackChanges);

				if (workouts is null)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(workouts);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
				return workouts;
			}
			workouts = JsonConvert.DeserializeObject<IEnumerable<Workout>>(cachedData);
			return workouts;
		}

		public async Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges)
		{
			var cacheKey = $"WorkoutByUserId_{userId}_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKey);

			Workout? workout;
			if (string.IsNullOrEmpty(cachedData))
			{
				workout = await _decorated.GetOneWorkoutByUserIdAsync(id, userId, trackChanges);

				return await AddToRedisCache(workout, cacheKey);
			}
			workout = JsonConvert.DeserializeObject<Workout>(cachedData);
			return workout;
		}

		public async Task<Workout?> GetOneWorkoutWithExercises(int id, string userId)
		{
			//TODO: Dto ile bu veriyi sadelestir
			var cacheKeyWithExercise = $"WorkoutWithExerciseByUserId_{userId}_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKeyWithExercise);

			Workout? workout;
			if (string.IsNullOrEmpty(cachedData))
			{
				workout = await _decorated.GetOneWorkoutWithExercises(id, userId);

				return await AddToRedisCache(workout, cacheKeyWithExercise);
			}
			workout = JsonConvert.DeserializeObject<Workout>(cachedData);
			return workout;
		}
		public void DeleteWorkout(string userId, Workout workout)
		{
			_decorated.DeleteWorkout(userId, workout);
			ClearCache(userId, workout.Id);
		}

		private void ClearCache(string userId, int id)
		{
			var cacheKey = $"WorkoutByUserId_{userId}_{id}";
			_redisCache.Remove(cacheKey);

			var listCacheKey = $"AllWorkoutsByUserId_{userId}";
			_redisCache.Remove(listCacheKey);

			var cacheKeyWithExercise = $"WorkoutWithExerciseByUserId_{userId}_{id}";
			_redisCache.Remove(cacheKeyWithExercise);
		}

		private async Task<Workout?> AddToRedisCache(Workout? workout, string cacheKey)
		{
			if (workout is null)
				return null;

			var serializedObject = JsonConvert.SerializeObject(workout,
				new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

			await _redisCache.SetStringAsync(cacheKey, serializedObject);
			return workout;
		}
	}
}
