
using Entities.DTOs.BodyMeasurement;
using Entities.Models;

namespace Repositories.RepoConcretes
{
	public interface IBodyMeasurementService
	{
		Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges);
		Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges);
		Task AddOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForInsertion bodyMeasurementDto);
		Task UpdateOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForUpdate bodyMeasurementDto, bool trackChanges);
		Task DeleteOneBodyMeasurementAsync(int id, string userId, bool trackChanges);
	}
}
