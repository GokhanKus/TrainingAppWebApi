using Entities.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.RepoConcretes;

namespace Repositories.DistributedCacheRepos
{
	public sealed class RedisCacheExerciseCategoryRepository : IExerciseCategoryRepository
	{
		private readonly IExerciseCategoryRepository _decorated;
		private readonly IDistributedCache _redisCache;
		public RedisCacheExerciseCategoryRepository(IExerciseCategoryRepository decorated, IDistributedCache redisCache)
		{
			_decorated = decorated;
			_redisCache = redisCache;
		}

		public async Task AddOneExerciseCategoryAsync(ExerciseCategory exerciseCategory)
		{
			await _decorated.AddOneExerciseCategoryAsync(exerciseCategory);
			var listCacheKey = $"AllExercises";
			await _redisCache.RemoveAsync(listCacheKey);
		}

		public async Task<IEnumerable<ExerciseCategory>?> GetAllExerciseCategoriesAsync(bool trackChanges)
		{
			var listCacheKey = $"AllExercises";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			IEnumerable<ExerciseCategory>? exerciseCategories;
			if (string.IsNullOrEmpty(cachedData))
			{
				exerciseCategories = await _decorated.GetAllExerciseCategoriesAsync(trackChanges);
				if (exerciseCategories is null)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(exerciseCategories);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
				return exerciseCategories;
			}

			exerciseCategories = JsonConvert.DeserializeObject<IEnumerable<ExerciseCategory>>(cachedData);
			return exerciseCategories;
		}

		public async Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges)
		{
			var cacheKey = $"ExerciseById_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKey);
			ExerciseCategory? exerciseCategory;
			if (string.IsNullOrEmpty(cachedData))
			{
				exerciseCategory = await _decorated.GetOneExerciseCategoryByIdAsync(id, trackChanges);

				return await AddToRedisCache(exerciseCategory, cacheKey);
			}
			exerciseCategory = JsonConvert.DeserializeObject<ExerciseCategory>(cachedData);
			return exerciseCategory;
		}

		public async Task<ExerciseCategory?> GetOneExerciseCategoryWithExercisesAsync(int id)
		{
			var cacheKeyWithExercise = $"ExerciseWithCategoryById_{id}";
			var cachedData = await _redisCache.GetStringAsync(cacheKeyWithExercise);
			ExerciseCategory? exerciseCategory;
			if (string.IsNullOrEmpty(cachedData))
			{
				exerciseCategory = await _decorated.GetOneExerciseCategoryWithExercisesAsync(id);

				return await AddToRedisCache(exerciseCategory, cacheKeyWithExercise);
			}
			exerciseCategory = JsonConvert.DeserializeObject<ExerciseCategory>(cachedData);
			return exerciseCategory;
		}
		public void DeleteOneExerciseCategory(ExerciseCategory exerciseCategory)
		{
			_decorated.DeleteOneExerciseCategory(exerciseCategory);
			ClearCache(exerciseCategory.Id);
		}

		public void UpdateOneExerciseCategory(ExerciseCategory exerciseCategory)
		{
			_decorated.UpdateOneExerciseCategory(exerciseCategory);
			ClearCache(exerciseCategory.Id);
		}
		private async Task<ExerciseCategory?> AddToRedisCache(ExerciseCategory? exerciseCategory, string cacheKey)
		{
			if (exerciseCategory is null)
				return null;
			var serializedObject = JsonConvert.SerializeObject(exerciseCategory,
				new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
			await _redisCache.SetStringAsync(cacheKey, serializedObject);
			return exerciseCategory;
		}
		private void ClearCache(int id)
		{
			var cacheKeyWithExercise = $"ExerciseWithCategoryById_{id}";
			_redisCache.Remove(cacheKeyWithExercise);

			var cacheKey = $"ExerciseById_{id}";
			_redisCache.Remove(cacheKey);

			var listCacheKey = $"AllExercises";
			_redisCache.Remove(listCacheKey);
		}
	}
}
