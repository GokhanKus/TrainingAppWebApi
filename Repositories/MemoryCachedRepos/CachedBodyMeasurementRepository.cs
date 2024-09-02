using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Memory;
using Repositories.RepoConcretes;

namespace Repositories.MemoryCachedRepos
{
    public sealed class CachedBodyMeasurementRepository : IBodyMeasurementRepository
    {
        private readonly IBodyMeasurementRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CachedBodyMeasurementRepository(IBodyMeasurementRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task AddOneBodyMeasurementAsync(string userId, BodyMeasurement bodyMeasurement)
        {
            bodyMeasurement.UserId = userId;
            await _decorated.AddOneBodyMeasurementAsync(userId, bodyMeasurement);

            _memoryCache.Remove($"AllBodyMeasurementsByUserId_{userId}");
        }

        public async Task<PagedList<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges)
        {
            var cacheKey = $"AllBodyMeasurementsByUserId_{userId}";
            var allBodyMeasurements = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetAllBodyMeasurementsByUserIdAsync(bodyMeasurementParameters, userId, trackChanges);
            });
            return allBodyMeasurements;
        }

        public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
        {
            var cacheKey = $"BodyMeasurementByUserId_{userId}_{id}";
            var bodyMeasurement = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);
            });
            return bodyMeasurement;
        }

        public void UpdateOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
        {
            bodyMeasurement.UserId = userId;  // userId güncelleniyor
            _decorated.UpdateOneBodyMeasurement(userId, bodyMeasurement);
            _memoryCache.Remove($"AllBodyMeasurementsByUserId_{userId}");
            _memoryCache.Remove($"BodyMeasurementByUserId_{userId}_{bodyMeasurement.Id}");
        }

        public void DeleteOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
        {
            bodyMeasurement.UserId = userId;  // userId kontrol ediliyor
            _decorated.DeleteOneBodyMeasurement(userId, bodyMeasurement);

            _memoryCache.Remove($"AllBodyMeasurementsByUserId_{userId}");
            _memoryCache.Remove($"BodyMeasurementByUserId_{userId}_{bodyMeasurement.Id}");
        }

		public Task<int> BodyMeasurementCountAsync(string userId)
		{
			throw new NotImplementedException();
		}
	}
}
