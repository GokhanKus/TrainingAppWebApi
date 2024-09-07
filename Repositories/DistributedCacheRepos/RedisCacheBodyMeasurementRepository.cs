using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.RepoConcretes;
using System.Linq;

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
			var pageNumbers = await GetPageNumberOfBodyMeasurement(userId);

			// Cache'yi invalid etmek (temizlemek) için ilgili anahtarı silin
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}_Page_{pageNumbers}";
			await _redisCache.RemoveAsync(listCacheKey);
		}
		public async Task<PagedList<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges)
		{
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}_Page_{bodyMeasurementParameters.PageNumber}";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);

			PagedList<BodyMeasurement>? measurements;
			if (string.IsNullOrEmpty(cachedData))
			{
				measurements = await _decorated.GetAllBodyMeasurementsByUserIdAsync(bodyMeasurementParameters, userId, trackChanges);

				if (measurements is null || measurements.Count == 0)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(measurements);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
				return measurements;
			}

			measurements = JsonConvert.DeserializeObject<PagedList<BodyMeasurement>?>(cachedData);
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
			ClearCacheAsync(userId, bodyMeasurement.Id).Wait();
		}
		public void DeleteOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
		{
			//bodyMeasurement.UserId = userId;  // userId kontrol ediliyor
			_decorated.DeleteOneBodyMeasurement(userId, bodyMeasurement);

			ClearCacheAsync(userId, bodyMeasurement.Id).Wait();
		}
		private async Task ClearCacheAsync(string userId, int id)
		{
			var cacheKey = $"BodyMeasurementByUserId_{userId}_{id}";
			await _redisCache.RemoveAsync(cacheKey);

			var pageNumbers = await GetPageNumberOfBodyMeasurement(userId);

			for (int pageNumber = 1; pageNumber <= pageNumbers; pageNumber++)
			{
				var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}_Page_{pageNumber}";
				await _redisCache.RemoveAsync(listCacheKey);
			}
		}
		public async Task<int> BodyMeasurementCountAsync(string userId)
		{
			var bodyMeasurementCount = await _decorated.BodyMeasurementCountAsync(userId);
			return bodyMeasurementCount;
		}
		private async Task<int> GetPageNumberOfBodyMeasurement(string userId)
		{
			var bodyMeasurementCount = await BodyMeasurementCountAsync(userId);
			var pageNumbers = (int)Math.Ceiling((bodyMeasurementCount / (double)10));
			return pageNumbers;
		}
	}
}
