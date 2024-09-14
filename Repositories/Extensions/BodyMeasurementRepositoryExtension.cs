using Entities.Models;

namespace Repositories.Extensions
{
	public static class BodyMeasurementRepositoryExtension
	{
		public static IQueryable<BodyMeasurement> FilterBodyMeasurementsByWeight(this IQueryable<BodyMeasurement> bodyMeasurements, uint? minWeight, uint? maxWeight)
		{
			if ((minWeight == 0 || minWeight is null) && (minWeight == 0 || minWeight is null))
				return bodyMeasurements;

			var filteredBodyMeasurement = bodyMeasurements.Where(b => ((b.Weight >= minWeight) && b.Weight <= maxWeight));
			return filteredBodyMeasurement;
		}
	}
}
