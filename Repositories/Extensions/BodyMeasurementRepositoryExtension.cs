using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.Extensions
{
	public static class BodyMeasurementRepositoryExtension
	{
		public static IQueryable<BodyMeasurement> FilterBodyMeasurementsByWeight(this IQueryable<BodyMeasurement> bodyMeasurements, uint? minWeight, uint? maxWeight)
		{
			if ((minWeight == 0 || minWeight is null) && (maxWeight == 0 || maxWeight is null))
				return bodyMeasurements;

			var filteredBodyMeasurement = bodyMeasurements.Where(b => ((b.Weight >= minWeight) && b.Weight <= maxWeight));
			return filteredBodyMeasurement;
		}
		public static IQueryable<BodyMeasurement> Sort(this IQueryable<BodyMeasurement> bodyMeasurements, string? orderByQueryString)
		{
			//bodymeasurement?orderBy = weight, bodyfatpercentage

			if (string.IsNullOrEmpty(orderByQueryString))//eger sıralamayla ilgili sorgu yoksa default id'ye gore siralasin
				return bodyMeasurements.OrderBy(b => b.Id);

			var orderQuery = OrderQueryBuilder.CreateOrderQuery<BodyMeasurement>(orderByQueryString);

			if (string.IsNullOrEmpty(orderQuery))
				return bodyMeasurements.OrderBy(b => b.Id);

			return bodyMeasurements.OrderBy(orderQuery); //weight ascending, bodyfatpercentage descending, id ascending'ye gore sirala
		}
	}
}
