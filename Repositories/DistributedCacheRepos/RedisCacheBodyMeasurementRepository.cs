using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repositories.Extensions;
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

			// Cache'yi invalid etmek (temizlemek) için ilgili anahtarı silin
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			await _redisCache.RemoveAsync(listCacheKey);
		}
		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges)
		{
			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			var cachedData = await _redisCache.GetStringAsync(listCacheKey);
			IEnumerable<BodyMeasurement>? bodyMeasurementsOfUser;
			if (string.IsNullOrEmpty(cachedData))
			{
				// Cache'de veri yoksa, veritabanından al
				bodyMeasurementsOfUser = await _decorated.GetAllBodyMeasurementsByUserIdAsync(bodyMeasurementParameters, userId, trackChanges);

				if (bodyMeasurementsOfUser == null || bodyMeasurementsOfUser.Count() == 0)
					return null;

				var serializedObjects = JsonConvert.SerializeObject(bodyMeasurementsOfUser);
				await _redisCache.SetStringAsync(listCacheKey, serializedObjects);
			}
			else
			{
				bodyMeasurementsOfUser = JsonConvert.DeserializeObject<PagedList<BodyMeasurement>>(cachedData);
			}
			return GetFilteredBodyMeasurementAndPaginate(bodyMeasurementParameters, bodyMeasurementsOfUser);
		}

		private IEnumerable<BodyMeasurement> GetFilteredBodyMeasurementAndPaginate(BodyMeasurementParameters bodyMeasurementParameters, IEnumerable<BodyMeasurement>? measurements)
		{
			var filteredBodyMeasurements = measurements
							.AsQueryable()
							.FilterBodyMeasurementsByWeight(bodyMeasurementParameters.MinWeight, bodyMeasurementParameters.MaxWeight);

			return PagedList<BodyMeasurement>.ToPagedList(filteredBodyMeasurements, bodyMeasurementParameters.PageNumber, bodyMeasurementParameters.PageSize);
		}

		public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
		{
			var cacheKey = $"BodyMeasurementByUserId_{userId}_{id}";

			var cachedData = await _redisCache.GetStringAsync(cacheKey);

			BodyMeasurement? bodyMeasurement;
			if (string.IsNullOrEmpty(cachedData))
			{
				bodyMeasurement = await _decorated.GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);
				return await AddToRedisCache(bodyMeasurement, cacheKey);
			}
			bodyMeasurement = JsonConvert.DeserializeObject<BodyMeasurement>(cachedData);
			return bodyMeasurement;
		}

		private async Task<BodyMeasurement?> AddToRedisCache(BodyMeasurement? bodyMeasurement, string cacheKey)
		{
			if (bodyMeasurement is null)
				return bodyMeasurement;

			var serializedObject = JsonConvert.SerializeObject(bodyMeasurement);
			await _redisCache.SetStringAsync(cacheKey, serializedObject);
			return bodyMeasurement;
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

			var listCacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			await _redisCache.RemoveAsync(listCacheKey);
		}
	}
}
