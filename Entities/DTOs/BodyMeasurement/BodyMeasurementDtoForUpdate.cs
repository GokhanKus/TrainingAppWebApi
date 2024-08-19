using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BodyMeasurement
{
	public sealed record BodyMeasurementDtoForUpdate : BodyMeasurementDto
	{
		public int Id { get; init; }
	}
}
