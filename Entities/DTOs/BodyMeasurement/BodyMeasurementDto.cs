using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BodyMeasurement
{
	public abstract record BodyMeasurementDto
	{
		public float Weight { get; init; }
		public float BodyFatPercentage { get; init; }
		public float MuscleMass { get; init; }
		public float WaistCircumference { get; init; }
	}
}
