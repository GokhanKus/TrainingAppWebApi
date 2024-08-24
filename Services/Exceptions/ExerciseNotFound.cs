using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
	public sealed class ExerciseNotFound : NotFoundException
	{
		public ExerciseNotFound(string message) : base(message)
		{
		}
	}
}
