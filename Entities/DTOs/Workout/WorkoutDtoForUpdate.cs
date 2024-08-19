using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ExerciseCategory
{
	public sealed record WorkoutDtoForUpdate : WorkoutDto
	{
		public int Id { get; init; }
	}
}
