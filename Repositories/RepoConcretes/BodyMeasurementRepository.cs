using Entities.Models;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class BodyMeasurementRepository : BaseRepository<BodyMeasurement>, IBodyMeasurementRepository
	{
		public BodyMeasurementRepository(RepositoryContext context) : base(context) { }

		public async Task AddOneBodyMeasurementAsync(string userId, BodyMeasurement bodyMeasurement)
		{
			bodyMeasurement.UserId = userId;
			await AddAsync(bodyMeasurement);
		}

		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges)
		{
			return await GetAllByConditionAsync(bm => bm.UserId == userId, trackChanges);
		}

		public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
		{
			return await GetByConditionAsync(bm => bm.Id == id && bm.UserId == userId, trackChanges);
		}

		public void UpdateOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
		{
			bodyMeasurement.UserId = userId;  // userId güncelleniyor
			Update(bodyMeasurement);
		}

		public void DeleteOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement)
		{
			bodyMeasurement.UserId = userId;  // userId kontrol ediliyor
			Delete(bodyMeasurement);
		}
	}
}
