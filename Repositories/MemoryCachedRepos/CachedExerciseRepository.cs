using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Memory;
using Repositories.RepoConcretes;

namespace Repositories.MemoryCachedRepos
{
	public class CachedExerciseRepository : IExerciseRepository
	{
		private readonly IExerciseRepository _decorated;
		private readonly IMemoryCache _memoryCache;
		public CachedExerciseRepository(IExerciseRepository decorated, IMemoryCache memoryCache)
		{
			_decorated = decorated;
			_memoryCache = memoryCache;
		}

		public async Task AddOneExerciseAsync(Exercise exercise)
		{
			await _decorated.AddOneExerciseAsync(exercise);

			// Cache temizlenecek çünkü yeni bir egzersiz eklendi.
			_memoryCache.Remove("AllExercises");
		}

		public void DeleteOneExercise(Exercise exercise)
		{
			_decorated.DeleteOneExercise(exercise);

			_memoryCache.Remove($"Exercise_{exercise.Id}");
			_memoryCache.Remove("AllExercises");
			_memoryCache.Remove($"ExerciseWithCategory_{exercise.Id}");
		}

		public Task<int> ExerciseCountAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Exercise>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges)
		{
			var cacheKey = "AllExercises";

			var allExercises = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
			{
				entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
				return _decorated.GetAllExercisesAsync(exerciseParameters, trackChanges);
			});
			return allExercises;
		}

		public async Task<Exercise?> GetOneExerciseByIdAsync(int id, bool trackChanges)
		{
			var cacheKey = $"Exercise_{id}";

			var exerciseById = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
			{
				entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
				return _decorated.GetOneExerciseByIdAsync(id, trackChanges);
			});
			return exerciseById;
		}

		public async Task<Exercise?> GetOneExerciseWithCategoryAsync(int id)
		{
			var cacheKey = $"ExerciseWithCategory_{id}";

			var exerciseWithCategory = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
			{
				entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
				return _decorated.GetOneExerciseWithCategoryAsync(id);
			});
			return exerciseWithCategory;
		}

		public void UpdateOneExercise(Exercise exercise)
		{
			_decorated.UpdateOneExercise(exercise);

			//service katmaninda update metodunu calistirmaya gerek kalmıyor trackchanges true oldugundan dolayı dogrudan save ediliyor o yuzden bu metot calismiyor.
			//yani eger bir exercise guncellenirse 2 dk sonra degisiklikler yansiyacak, duzeltilebilir..
			// Güncellenen egzersizin ve tüm egzersizlerin cache'i temizlenecek
			_memoryCache.Remove($"Exercise_{exercise.Id}");
			_memoryCache.Remove($"ExerciseWithCategory_{exercise.Id}");
			_memoryCache.Remove("AllExercises");
		}
	}
}
