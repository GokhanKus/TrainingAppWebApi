using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
	public static class BodyMeasurementRepositoryExtension
	{
		public static IQueryable<BodyMeasurement> Paginate(this IQueryable<BodyMeasurement> bodyMeasurements, int pageNumber, int pageSize)
		{
			return bodyMeasurements
				.Skip((pageNumber - 1) * pageSize) // IIIII IIIII IIIII örnegin 3.sayfaya gitmek istersem (3-1) * 5 = 10 tane item atlayacagimi soyluyorum
				.Take(pageSize);
		}
	}
}
