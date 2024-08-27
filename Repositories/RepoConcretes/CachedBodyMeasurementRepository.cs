using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Repositories.Context;
using Repositories.RepoBases;
using System.Linq.Expressions;

namespace Repositories.RepoConcretes
{
	public sealed class CachedBodyMeasurementRepository : IBodyMeasurementRepository
	{
		private readonly IBodyMeasurementRepository _decorated;
		private readonly IMemoryCache _memoryCache;

		public CachedBodyMeasurementRepository(IBodyMeasurementRepository bodyMeasurementRepository, IMemoryCache memoryCache)
		{
			_decorated = bodyMeasurementRepository;
			_memoryCache = memoryCache;
		}

		public async Task AddOneBodyMeasurementAsync(string userId, BodyMeasurement bodyMeasurement)
		{
			bodyMeasurement.UserId = userId;
			await _decorated.AddOneBodyMeasurementAsync(userId, bodyMeasurement);

			_memoryCache.Remove($"AllBodyMeasurementsByUserId_{userId}");
		}

		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges)
		{
			var cacheKey = $"AllBodyMeasurementsByUserId_{userId}";
			var allBodyMeasurements = await _memoryCache.GetOrCreateAsync(cacheKey, entry =>
			{
				entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
				return _decorated.GetAllBodyMeasurementsByUserIdAsync(userId, trackChanges);
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
	}
}
