using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class ExerciseCategoryNotFoundException : NotFoundException
	{
		public ExerciseCategoryNotFoundException(int id) : base($"The exercise category you looked for with id: {id} could not found")
		{
		}
	}
}
