using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.ServiceConcretes
{
	public interface IBodyMeasurementService
	{
		Task<IEnumerable<ExpandoObject>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges);
		Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges);
		Task AddOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForInsertion bodyMeasurementDto);
		Task UpdateOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForUpdate bodyMeasurementDto, bool trackChanges);
		Task DeleteOneBodyMeasurementAsync(int id, string userId, bool trackChanges);
	}
}
