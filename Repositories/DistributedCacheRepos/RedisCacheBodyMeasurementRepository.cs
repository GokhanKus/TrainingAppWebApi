using Entities.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Repositories.RepoConcretes;

namespace Repositories.DistributedCacheRepos
{
	public sealed class RedisCacheBodyMeasurementRepository : IBodyMeasurementRepository
	{
		private readonly IBodyMeasurementRepository _decorated;
		private readonly IDistributedCache _redisCache;

		public RedisCacheBodyMeasurementRepository(IBodyMeasurementRepository distributed, IDistributedCache redisCache)
		{
			_decorated = distributed;
			_redisCache = redisCache;
		}

		public async Task AddOneBodyMeasurementAsync(string userId, BodyMeasurement bodyMeasurement)
		{
			await _decorated.AddOneBodyMeasurementAsync(userId, bodyMeasurement);

			// Cache'yi invalid etmek (temizlemek) için ilgili anahtarı silin
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			await _redisCache.RemoveAsync(listCacheKey);
		}

		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges)
		{
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";

			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			IEnumerable<BodyMeasurement>? measurements;
			if (string.IsNullOrEmpty(cachedData))
			{
				measurements = await _decorated.GetAllBodyMeasurementsByUserIdAsync(userId, trackChanges);

				if (measurements is null)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(measurements);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
				return measurements;
			}

			measurements = JsonConvert.DeserializeObject<IEnumerable<BodyMeasurement>>(cachedData);
			return measurements;
		}

		public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
		{
			var cacheKey = $"BodyMeasurementByUserId_{userId}_{id}";

			var cachedData = await _redisCache.GetStringAsync(cacheKey);

			BodyMeasurement? member;
			if (string.IsNullOrEmpty(cachedData))
			{
				member = await _decorated.GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);

				if (member is null)
					return member;

				var serializedObject = JsonConvert.SerializeObject(member);
				await _redisCache.SetStringAsync(cacheKey, serializedObject);
				return member;
			}
			member = JsonConvert.DeserializeObject<BodyMeasurement>(cachedData);
			return member;
		}

		public void UpdateOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
		{
			//burada update etmemize gerek yok cunku trackchanges true olarak geliyor sadece service katmanindan buraya yonlendirerek cacheleri temizlemek yeterli
			//cunku veri degisiyor, eger buraya yonlendirmezsek updateden sonra veri ayni kalir cunku veri redisten(onbellekten) geliyor
			_decorated.UpdateOneBodyMeasurement(userId, bodyMeasurement);

			// Cache'yi invalid etmek (temizlemek) için ilgili anahtarı silin
			ClearCache(userId, bodyMeasurement.Id);
		}

		public void DeleteOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
		{
			//bodyMeasurement.UserId = userId;  // userId kontrol ediliyor
			_decorated.DeleteOneBodyMeasurement(userId, bodyMeasurement);

			ClearCache(userId, bodyMeasurement.Id);
		}
		private void ClearCache(string userId, int id)
		{
			var cacheKey = $"BodyMeasurementByUserId_{userId}_{id}";
			_redisCache.Remove(cacheKey);

			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			_redisCache.Remove(listCacheKey);
		}
	}
}
