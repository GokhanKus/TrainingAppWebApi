using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public class WeightOutOfRangeBadRequestException : BadRequestException
	{
		public WeightOutOfRangeBadRequestException() : base("max weight must be greater than min weight")
		{
		}
	}
}
