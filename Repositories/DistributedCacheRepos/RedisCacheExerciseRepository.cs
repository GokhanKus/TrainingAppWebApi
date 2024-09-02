using Entities.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.RepoConcretes;

namespace Repositories.DistributedCacheRepos
{
	public sealed class RedisCacheExerciseRepository : IExerciseRepository
	{
		private readonly IExerciseRepository _decorated;
		private readonly IDistributedCache _redisCache;

		public RedisCacheExerciseRepository(IExerciseRepository decorated, IDistributedCache redisCache)
		{
			_decorated = decorated;
			_redisCache = redisCache;
		}

		public async Task AddOneExerciseAsync(Exercise exercise)
		{
			await _decorated.AddOneExerciseAsync(exercise);
			ClearCache();
		}

		public async Task<IEnumerable<Exercise>?> GetAllExercisesAsync(bool trackChanges)
		{
			var listCacheKey = $"AllExercises";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			IEnumerable<Exercise>? exercises;
			if (string.IsNullOrEmpty(cachedData))
			{
				exercises = await _decorated.GetAllExercisesAsync(trackChanges);
				if (exercises is null)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(exercises);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
				return exercises;
			}
			exercises = JsonConvert.DeserializeObject<IEnumerable<Exercise>>(cachedData);
			return exercises;
		}

		public async Task<Exercise?> GetOneExerciseByIdAsync(int id, bool trackChanges)
		{
			var cacheKey = $"ExerciseById_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKey);

			Exercise? exercise;
			if (string.IsNullOrEmpty(cachedData))
			{
				exercise = await _decorated.GetOneExerciseByIdAsync(id, trackChanges);
				return await AddToRedisCache(exercise, cacheKey);
			}
			exercise = JsonConvert.DeserializeObject<Exercise>(cachedData);
			return exercise;
		}

		public async Task<Exercise?> GetOneExerciseWithCategoryAsync(int id)
		{
			var cacheKeyWithCategory = $"ExerciseWithCategoryById_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKeyWithCategory);

			Exercise? exercise;
			if (string.IsNullOrEmpty(cachedData))
			{
				exercise = await _decorated.GetOneExerciseWithCategoryAsync(id);
				return await AddToRedisCache(exercise, cacheKeyWithCategory);
			}
			exercise = JsonConvert.DeserializeObject<Exercise>(cachedData);
			return exercise;
		}

		public void UpdateOneExercise(Exercise exercise)
		{
			_decorated.UpdateOneExercise(exercise);
			ClearCache(exercise.Id);
		}
		public void DeleteOneExercise(Exercise exercise)
		{
			_decorated.DeleteOneExercise(exercise);
			ClearCache(exercise.Id);
		}
		private async Task<Exercise?> AddToRedisCache(Exercise? exercise, string cacheKey)
		{
			if (exercise is null)
				return null;

			var serializedObject = JsonConvert.SerializeObject(exercise,
				new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			await _redisCache.SetStringAsync(cacheKey, serializedObject);
			return exercise;
		}
		private void ClearCache(int id = 0)
		{
			var listCacheKey = $"AllExercises";
			_redisCache.Remove(listCacheKey);

			if (id == 0)
				return;

			var cacheKeyWithCategory = $"ExerciseWithCategoryById_{id}";
			_redisCache.Remove(cacheKeyWithCategory);

			var cacheKey = $"ExerciseById_{id}";
			_redisCache.Remove(cacheKey);

		}
	}
}
