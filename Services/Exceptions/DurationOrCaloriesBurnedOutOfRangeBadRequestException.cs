using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public class DurationOrCaloriesBurnedOutOfRangeBadRequestException : BadRequestException
	{
		public DurationOrCaloriesBurnedOutOfRangeBadRequestException() : base("max duration and max calories burned must be greater than min duration and min calories burned")
		{

		}
	}
}
