using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class BodyMeasurementNotFoundException : NotFoundException
	{
		public BodyMeasurementNotFoundException(string message) : base(message)
		{
		}
	}
}
