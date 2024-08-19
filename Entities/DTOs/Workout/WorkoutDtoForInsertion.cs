using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs.WorkoutExercise;

namespace Entities.DTOs.ExerciseCategory
{
	public sealed record WorkoutDtoForInsertion : WorkoutDto
	{
		public ICollection<WorkoutExerciseDtoForInsertion> WorkoutExercises { get; set; } = new List<WorkoutExerciseDtoForInsertion>();
	}
}
