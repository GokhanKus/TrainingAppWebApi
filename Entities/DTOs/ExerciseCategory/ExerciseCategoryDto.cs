using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ExerciseCategory
{
	public abstract record ExerciseCategoryDto
	{
		public string? Name { get; init; }
		public string? Description { get; init; }
	}
}
