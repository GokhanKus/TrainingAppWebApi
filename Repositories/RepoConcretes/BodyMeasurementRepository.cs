using Entities.Models;
using Entities.RequestFeatures;
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

		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges)
		{
			var bodyMeasurementsOfUser = await GetAllByConditionAsync(bm => bm.UserId == userId, trackChanges);
			return bodyMeasurementsOfUser;
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

		public async Task<int> BodyMeasurementCountAsync(string userId)
		{
			var bodyMeasurements = await CountAsync(bm => bm.UserId == userId);
			return bodyMeasurements;
		}
	}
}
