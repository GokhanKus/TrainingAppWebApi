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

			var pageNumber = await GetPageNumberOfExercise();
			var listCacheKey = $"AllExercises_Page_{pageNumber}";
			await _redisCache.RemoveAsync(listCacheKey);
		}

		public async Task<PagedList<Exercise>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges)
		{
			var listCacheKey = $"AllExercises_Page_{exerciseParameters.PageNumber}";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			PagedList<Exercise>? exercises;
			IQueryable<Exercise>? filteredExercises;
			if (string.IsNullOrEmpty(cachedData))
			{
				exercises = await _decorated.GetAllExercisesAsync(exerciseParameters, trackChanges);
				if (exercises is null || exercises.Count == 0)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(exercises);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);

				//return exercises;
				return GetFilteredExercises(exerciseParameters, exercises, out filteredExercises);
			}
			exercises = JsonConvert.DeserializeObject<PagedList<Exercise>>(cachedData);

			return GetFilteredExercises(exerciseParameters, exercises, out filteredExercises);
		}

		private static PagedList<Exercise> GetFilteredExercises(ExerciseParameters exerciseParameters, PagedList<Exercise>? exercises, out IQueryable<Exercise>? filteredExercises)
		{
			filteredExercises = exercises
				.AsQueryable()
				.FilterExerciseByNameOrDescription(exerciseParameters.SearchingTerm).FilterExerciseByDifficulty(exerciseParameters.DifficultyLevel);
			return PagedList<Exercise>.ToPagedListForFilteredData(filteredExercises, exerciseParameters.PageNumber, exerciseParameters.PageSize);
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
			var pageNumbers = await GetPageNumberOfExercise();

			for (int pageNumber = 1; pageNumber <= pageNumbers; pageNumber++)
			{
				var listCacheKey = $"AllExercises_Page_{pageNumber}";
				await _redisCache.RemoveAsync(listCacheKey);
			}

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

		public async Task<int> ExerciseCountAsync()
		{
			var exerciseCount = await _decorated.ExerciseCountAsync();
			return exerciseCount;
		}
		private async Task<int> GetPageNumberOfExercise()
		{
			var exerciseCount = await ExerciseCountAsync();
			var pageNumbers = (int)Math.Ceiling((exerciseCount / (double)10));
			return pageNumbers;
		}
	}
}
