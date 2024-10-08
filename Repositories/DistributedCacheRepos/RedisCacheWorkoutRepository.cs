﻿using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.Extensions;
using Repositories.RepoConcretes;

namespace Repositories.DistributedCacheRepos
{
	public sealed class RedisCacheWorkoutRepository : IWorkoutRepository
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

		public async Task<IEnumerable<Workout>?> GetAllWorkoutsByUserIdAsync(WorkoutParameters workoutParameters, string userId, bool trackChanges)
		{
			var listCacheKey = $"AllWorkoutsByUserId_{userId}";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);
			IEnumerable<Workout>? workouts;
			if (string.IsNullOrEmpty(cachedData))
			{
				workouts = await _decorated.GetAllWorkoutsByUserIdAsync(workoutParameters, userId, trackChanges);

				//gelen veri null ise veya count = 0 ise null olarak donsun, cunku null veriyi cachelemenin anlami yok
				if (workouts is null || workouts.Count() == 0)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(workouts);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
			}
			else
			{
				workouts = JsonConvert.DeserializeObject<PagedList<Workout>>(cachedData);
			}

			return GetFilteredWorkoutsAndPaginate(workoutParameters, workouts);
		}
		private IEnumerable<Workout> GetFilteredWorkoutsAndPaginate(WorkoutParameters workoutParameters, IEnumerable<Workout>? workouts)
		{
			var filteredWorkouts = workouts
							.AsQueryable()
							.FilterWorkoutByCaloriesBurned(workoutParameters.MinCaloriesBurned, workoutParameters.MaxCaloriesBurned)
							.FilterWorkoutByDuration(workoutParameters.MinDuration, workoutParameters.MaxDuration)
							.Sort(workoutParameters.OrderBy);

			return PagedList<Workout>.ToPagedList(filteredWorkouts, workoutParameters.PageNumber, workoutParameters.PageSize);
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
			ClearCacheAsync(userId, workout.Id).Wait();
		}

		private async Task ClearCacheAsync(string userId, int id)
		{
			var cacheKey = $"WorkoutByUserId_{userId}_{id}";
			await _redisCache.RemoveAsync(cacheKey);

			var cacheKeyWithExercise = $"WorkoutWithExerciseByUserId_{userId}_{id}";
			await _redisCache.RemoveAsync(cacheKeyWithExercise);

			var listCacheKey = $"AllWorkoutsByUserId_{userId}";
			await _redisCache.RemoveAsync(listCacheKey);

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
