using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class ExerciseCategoryNotFound : NotFoundException
	{
		public ExerciseCategoryNotFound(string message) : base(message)
		{
		}
	}
}
