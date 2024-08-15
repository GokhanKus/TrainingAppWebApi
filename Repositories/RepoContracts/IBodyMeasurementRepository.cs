using Entities.Models;
using Repositories.RepoBases;

namespace Repositories.RepoConcretes
{
	public interface IBodyMeasurementRepository : IBaseRepository<BodyMeasurement>
	{
		Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurementsByUserIdAsync(int userId, bool trackChanges);
		Task<BodyMeasurement> GetOneBodyMeasurementByUserIdAsync(int userId, bool trackChanges);
		Task AddOneBodyMeasurementAsync(int userId, BodyMeasurement bodyMeasurement);
		void UpdateOneBodyMeasurement(int userId, BodyMeasurement bodyMeasurement);
		void DeleteOneBodyMeasurement(int userId, BodyMeasurement bodyMeasurement);
	}
}
