using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class ExerciseNotFoundException : NotFoundException
	{
		public ExerciseNotFoundException(int id) : base($"the exercise you looked for with id: {id} could not found")
		{
		}
	}
}
