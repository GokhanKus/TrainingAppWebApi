using Entities.Models;
using Repositories.Context;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public sealed class BodyMeasurementRepository : BaseRepository<BodyMeasurement>, IBodyMeasurementRepository
	{
		public BodyMeasurementRepository(RepositoryContext context) : base(context) { }

		public Task AddOneBodyMeasurementAsync(int userId, BodyMeasurement bodyMeasurement)
		{
			throw new NotImplementedException();
		}

		public void DeleteOneBodyMeasurement(int userId, BodyMeasurement bodyMeasurement)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurementsByUserIdAsync(int userId, bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public Task<BodyMeasurement> GetOneBodyMeasurementByUserIdAsync(int userId, bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public void UpdateOneBodyMeasurement(int userId, BodyMeasurement bodyMeasurement)
		{
			throw new NotImplementedException();
		}
	}
}
