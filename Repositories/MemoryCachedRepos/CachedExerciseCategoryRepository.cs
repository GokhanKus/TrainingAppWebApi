using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Repositories.RepoConcretes;

namespace Repositories.MemoryCachedRepos
{
    public sealed class CachedExerciseCategoryRepository : IExerciseCategoryRepository
    {
        private readonly IExerciseCategoryRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        public CachedExerciseCategoryRepository(IExerciseCategoryRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task AddOneExerciseCategoryAsync(ExerciseCategory exerciseCategory)
        {
            await _decorated.AddOneExerciseCategoryAsync(exerciseCategory);
            _memoryCache.Remove("AllExerciseCategories");
        }
        public void DeleteOneExerciseCategory(ExerciseCategory exerciseCategory)
        {
            _decorated.DeleteOneExerciseCategory(exerciseCategory);

            _memoryCache.Remove("AllExerciseCategories");
            _memoryCache.Remove($"ExerciseCategory_{exerciseCategory.Id}");
            _memoryCache.Remove($"ExerciseCategoryWithExercises_{exerciseCategory.Id}");
        }

        public void UpdateOneExerciseCategory(ExerciseCategory exerciseCategory)
        {
            _decorated.UpdateOneExerciseCategory(exerciseCategory);

            _memoryCache.Remove("AllExerciseCategories");
            _memoryCache.Remove($"ExerciseCategory_{exerciseCategory.Id}");
            _memoryCache.Remove($"ExerciseCategoryWithExercises_{exerciseCategory.Id}");
        }
        public async Task<IEnumerable<ExerciseCategory>?> GetAllExerciseCategoriesAsync(bool trackChanges)
        {
            var cacheKey = "AllExerciseCategories";

            var allExerciseCategories = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetAllExerciseCategoriesAsync(trackChanges);
            });
             return allExerciseCategories;
        }
        public async Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges)
        {
            var cacheKey = $"ExerciseCategory_{id}";

            var exerciseCategory = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetOneExerciseCategoryByIdAsync(id, trackChanges);
            });
            return exerciseCategory;
        }
        public async Task<ExerciseCategory?> GetOneExerciseCategoryWithExercisesAsync(int id)
        {
            var cacheKey = $"ExerciseCategoryWithExercises_{id}";

            var exerciseCategoryWithExercises = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetOneExerciseCategoryWithExercisesAsync(id);
            });
            return exerciseCategoryWithExercises;
        }
    }
}
