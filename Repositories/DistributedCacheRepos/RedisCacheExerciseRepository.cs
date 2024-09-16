using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.Extensions;
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

			var listCacheKey = $"AllExercises";
			await _redisCache.RemoveAsync(listCacheKey);
		}

		public async Task<IEnumerable<Exercise>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges)
		{
			var listCacheKey = $"AllExercises";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);
			IEnumerable<Exercise>? exercises;
			if (string.IsNullOrEmpty(cachedData))
			{
				// Veritabanından ham verileri al ve cache'e kaydet
				exercises = await _decorated.GetAllExercisesAsync(exerciseParameters, trackChanges);
				if (exercises == null || exercises.Count() == 0)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(exercises);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
			}
			else
			{
				exercises = JsonConvert.DeserializeObject<PagedList<Exercise>>(cachedData);
			}
			return GetFilteredExercisesAndPaginate(exerciseParameters, exercises);
		}

		private PagedList<Exercise> GetFilteredExercisesAndPaginate(ExerciseParameters exerciseParameters, IEnumerable<Exercise>? exercises )
		{
			var filteredExercises = exercises
				.AsQueryable()
				.FilterExerciseByDifficulty(exerciseParameters.DifficultyLevel)
				.Search(exerciseParameters.SearchingTerm);

			return PagedList<Exercise>.ToPagedList(filteredExercises, exerciseParameters.PageNumber, exerciseParameters.PageSize);
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
			ClearCacheAsync(exercise.Id).Wait();
		}
		public void DeleteOneExercise(Exercise exercise)
		{
			_decorated.DeleteOneExercise(exercise);
			ClearCacheAsync(exercise.Id).Wait();
		}
		private async Task ClearCacheAsync(int id)
		{
			var listCacheKey = $"AllExercises";
			await _redisCache.RemoveAsync(listCacheKey);

			var cacheKeyWithCategory = $"ExerciseWithCategoryById_{id}";
			await _redisCache.RemoveAsync(cacheKeyWithCategory);

			var cacheKey = $"ExerciseById_{id}";
			await _redisCache.RemoveAsync(cacheKey);

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
	}
}
