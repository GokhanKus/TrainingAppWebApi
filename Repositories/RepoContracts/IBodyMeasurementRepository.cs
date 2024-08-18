using Entities.Models;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public interface IBodyMeasurementRepository : IBaseRepository<BodyMeasurement>
	{
		Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges);
		Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges);
		Task AddOneBodyMeasurementAsync(string userId, BodyMeasurement bodyMeasurement);
		void UpdateOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement);
		void DeleteOneBodyMeasurement(string userId, BodyMeasurement bodyMeasurement);
	}
}
